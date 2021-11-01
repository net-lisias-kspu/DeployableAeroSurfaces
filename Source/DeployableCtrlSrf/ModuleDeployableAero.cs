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
using System;
using UnityEngine;
using System.Collections.Generic;
using Log = DeployableAeroSurfaces.Log;

namespace DeployableAeroSurfaces
{
    class ModuleDeployableAero : PartModule
    {
        //Index of ModuleAnimateGeneric (Or other module implementing IScalarModule)
        [KSPField]
        public int DeployModuleIndex = 0;

        //Position of deploy module
        [KSPField]
        public int DeployModulePos = 0;

        private IScalarModule deployModule;
        private ModuleLiftingSurface[] surfaces;
        private List<float> lifts = new List<float>();
        private List<float> ranges = new List<float>();

        public override void OnStart(StartState state)
        {
            base.OnStart(state);
            deployModule = part.Modules[DeployModuleIndex] as IScalarModule;
            surfaces = part.FindModulesImplementing<ModuleLiftingSurface>().ToArray();

            for (int i = 0; i < surfaces.Length; i++)
            {
                lifts.Add(surfaces[i].deflectionLiftCoeff);
                if (surfaces[i].GetType() == typeof(ModuleControlSurface) | surfaces[i].GetType() == typeof(ModuleAeroSurface))
                {
                    ModuleControlSurface srf = surfaces[i] as ModuleControlSurface;
                    ranges.Add(srf.ctrlSurfaceRange);
                }
            }

            deployModule.OnStop.Add(UpdateSurfaces);
            UpdateSurfaces(deployModule.GetScalar);
        }

        public void UpdateSurfaces(float pos)
        {
            if (pos == DeployModulePos)
            {
                for (int i = 0; i < surfaces.Length; i++)
                {
                    surfaces[i].deflectionLiftCoeff = lifts[i];
                    if (surfaces[i].GetType() == typeof(ModuleControlSurface) | surfaces[i].GetType() == typeof(ModuleAeroSurface))
                    {
                        ModuleControlSurface srf = surfaces[i] as ModuleControlSurface;
                        srf.ctrlSurfaceRange = ranges[0];
                    }
                }
            }
            else
            {
                for (int i = 0; i < surfaces.Length; i++)
                {
                    surfaces[i].deflectionLiftCoeff = 0.0001f;
                    if (surfaces[i].GetType() == typeof(ModuleControlSurface) | surfaces[i].GetType() == typeof(ModuleAeroSurface))
                    {
                        ModuleControlSurface srf = surfaces[i] as ModuleControlSurface;
                        srf.ctrlSurfaceRange = 0.0001f;
                    }
                }
            }
        }
    }
}
