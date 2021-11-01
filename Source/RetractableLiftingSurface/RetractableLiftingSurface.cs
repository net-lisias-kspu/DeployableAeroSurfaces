/*
	This file is part of Deployable Aero Surfaces /L Unleashed
		© 2018-2021 Lisias T : http://lisias.net <support@lisias.net>

	Deployable Aero Surfaces /L is double licensed, as follows:
		* SKL 1.0 : https://ksp.lisias.net/SKL-1_0.txt
		* GPL 2.0 : https://www.gnu.org/licenses/gpl-2.0.txt

	And you are allowed to choose the License that better suit your needs.

	Deployable Aero Surfaces /L Unleashed is distributed in the hope that it
	will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty
	of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the SKL Standard License 1.0
	along with Deployable Aero Surfaces /L Unleashed.
	If not, see <https://ksp.lisias.net/SKL-1_0.txt>.

	You should have received a copy of the GNU General Public License 2.0
	along with Deployable Aero Surfaces /L Unleashed.
	If not, see <https://www.gnu.org/licenses/>.

*/
using System.Linq;
using UnityEngine;

using Log = DeployableAeroSurfaces.Log;

namespace RetractableLiftingSurface
{
    public class RetractableLiftingSurface : ModuleLiftingSurface
    {
        [KSPField(isPersistant = true, guiActive = false, guiActiveEditor = false)]
        public float retractedDeflectionLiftCoeff = 0.0F;

        [KSPField(isPersistant = true, guiActive = false, guiActiveEditor = false)]
        public float extendedDeflectionLiftCoeff = 1.0F;

        [KSPField(isPersistant = true, guiActive = false, guiActiveEditor = false)]
        public int retracted = 1;


        [KSPField(isPersistant = true, guiActive = false, guiActiveEditor = false)]
        public float retractedCtlSfcDeflectionLiftCoeff = 0.0F;

        [KSPField(isPersistant = true, guiActive = false, guiActiveEditor = false)]
        public float extendedCtlSfcDeflectionLiftCoeff = 1.0F;



        const string modName = "RetractableLiftingSurface";

        // the animation for the retractable lifting surface (ie: folding wings)
        private ModuleAnimateGeneric deployAnimation;

        // an integrated control surface, if needed
        private ModuleControlSurface controlSurface;

        float maxCtrlSurfaceRange;
        float ctrlSurfaceRange = 0.0001f;
        bool ctrlSurfaceActive = false;
        double timeActive;

        bool ignorePitch;
        bool ignoreRoll;
        bool ignoreYaw;
        float lastAnimtime;

        public override void OnStart(StartState state)
        {
            deployAnimation = GetDeployAnimation();
            if (deployAnimation == null)
            {
                Log.warn("RetractableLiftingSurface can't find a deploy animation for: {0}", this.part.partInfo.title);
                Destroy(this);
                return;
            }
            controlSurface = GetControlSurface();
            lastAnimtime = deployAnimation.animTime;
            if (controlSurface)
            {
                ignorePitch = controlSurface.ignorePitch;
                ignoreRoll = controlSurface.ignoreRoll;
                ignoreYaw = controlSurface.ignoreYaw;
                maxCtrlSurfaceRange = controlSurface.ctrlSurfaceRange;
                if (!ignoreRoll)
                {
                    ctrlSurfaceRange = controlSurface.ctrlSurfaceRange;
                    ctrlSurfaceActive = true;
                }
                else
                {
                    ctrlSurfaceRange = 0;
                    ctrlSurfaceActive = false;
                }

            }
            base.OnStart(state);
        }

        public void LateUpdate()
        {
            if (HighLogic.LoadedSceneIsEditor)
                lastAnimtime = deployAnimation.animTime;

            Log.dbg("lastAnimtime: {0}  deployAnimation.animTime: {1}", lastAnimtime, deployAnimation.animTime);
            float m;
            if (retracted == 0)
            {
                m = deployAnimation.animTime;
            }
            else
            {
                m = 1.0f - deployAnimation.animTime;
            }
            if (controlSurface != null)
            {
                controlSurface.deflectionLiftCoeff = (extendedCtlSfcDeflectionLiftCoeff - retractedCtlSfcDeflectionLiftCoeff) * m + retractedCtlSfcDeflectionLiftCoeff;
                if (HighLogic.LoadedSceneIsFlight)
                {
                    if (lastAnimtime != deployAnimation.animTime)
                    {
                        ctrlSurfaceActive = false;
                        controlSurface.ctrlSurfaceRange = 0.0001f;

                        lastAnimtime = deployAnimation.animTime;
                        if (m == 1)
                        {
                            controlSurface.ignorePitch = ignorePitch;
                            controlSurface.ignoreRoll = ignoreRoll;
                            controlSurface.ignoreYaw = ignoreYaw;
                            
                            timeActive = Planetarium.GetUniversalTime();
                        }
                        else
                        {
                            controlSurface.ignorePitch = true;
                            controlSurface.ignoreRoll = true;
                            controlSurface.ignoreYaw = true;
                            
                            controlSurface.ctrlSurfaceRange = 0.0001f;
                        }
                    }
                    else
                    {
                        ctrlSurfaceActive = true;
                        if (m == 1)
                        {
                            ignorePitch = controlSurface.ignorePitch;
                            ignoreRoll = controlSurface.ignoreRoll;
                            ignoreYaw = controlSurface.ignoreYaw;                           
                        }
                    }
                    if(ctrlSurfaceActive && controlSurface.ctrlSurfaceRange != maxCtrlSurfaceRange)
                    {
                        // by using 1 second, we avoid the need for any division
                        if (Planetarium.GetUniversalTime() - timeActive >= 1.0)
                        {
                            ctrlSurfaceActive = false;
                            controlSurface.ctrlSurfaceRange = maxCtrlSurfaceRange;
                        }
                        else
                        {
                            controlSurface.ctrlSurfaceRange = maxCtrlSurfaceRange * (float)(Planetarium.GetUniversalTime() - timeActive);
                        }
                    }
                }
            }

            deflectionLiftCoeff = (extendedDeflectionLiftCoeff - retractedDeflectionLiftCoeff) * m + retractedDeflectionLiftCoeff;
        }

        public override string GetInfo()
        {
            return "Retracted Relative Wing Area: " + this.retractedDeflectionLiftCoeff + "\nExtended Relative Wing Area: " + this.extendedDeflectionLiftCoeff;
        }

        private ModuleAnimateGeneric GetDeployAnimation()
        {
            ModuleAnimateGeneric myAnimation = null;

            try
            {
                myAnimation = part.FindModulesImplementing<ModuleAnimateGeneric>().SingleOrDefault();
            }
            catch (System.Exception x)
            {
                Log.error("{0} ERROR: {1}", modName, x.Message);
            }

            return myAnimation;
        }

        private ModuleControlSurface GetControlSurface()
        {
            ModuleControlSurface myControlSurface = null;

            myControlSurface = part.FindModulesImplementing<ModuleControlSurface>().SingleOrDefault();

            return myControlSurface;
        }
    }
}
