# Retractable Lifting Surface /L Unleashed

This is a small module which allows you to have a folding wing or other retractable lifting surface.

[Unleashed](https://ksp.lisias.net/add-ons-unleashed/) fork by Lisias.


## In a Hurry

* [Latest Release](https://github.com/net-lisias-kspu/RetractableLiftingSurface/releases)
	+ [Binaries](https://github.com/net-lisias-kspu/RetractableLiftingSurface/tree/Archive)
* [Source](https://github.com/net-lisias-kspu/RetractableLiftingSurface)
* [Project's README](https://github.com/net-lisias-kspu/RetractableLiftingSurface/blob/master/README.md)
* [Change Log](./CHANGE_LOG.md)
* [TODO](./TODO.md) list


## Description

This is a small module which allows you to have a folding wing or other retractable lifting surface.  It allows for an integrated control surface (only one at this time).

Additionally, the integrated control surface is eased in once the wing is deployed, so that it doesn't kick in instantly

### Instructions for use

Add the following module to the cfg file (which replaces the ModuleLiftingSurface):

```
MODULE
{
    name = RetractableLiftingSurface
    retracted = 1   // this value comes from the animation  If you find that you are getting
                    // lift when retracted, and no lift when extended, set this to 0
    retractedDeflectionLiftCoeff = 0
    extendedDeflectionLiftCoeff = 1.37 // 4.83m^
    useInternalDragModel = True

    // If no control surface as part of this lifting surface, then no need for
    // following two lines
    retractedCtlSfcDeflectionLiftCoeff = 0
    extendedCtlSfcDeflectionLiftCoeff = 1.25
}
```

### Known Clients

* [Kerbonov Kn-2 Cockpit Module](http://forum.kerbalspaceprogram.com/index.php?/topic/60380-*)
* [REKT Escape Pod Mod](http://forum.kerbalspaceprogram.com/index.php?/topic/150837-*)
* [CONTARES 1.8.1 with addons for Tantares and TantaresLV](http://forum.kerbalspaceprogram.com/index.php?/topic/122102-*)
* [SXT Continued](http://forum.kerbalspaceprogram.com/index.php?/topic/151129-*)
* [Tunda Exploration](https://forum.kerbalspaceprogram.com/index.php?/topic/166915-*/)
* [KNES](https://forum.kerbalspaceprogram.com/index.php?/topic/164035-173-knes-13/)


## Installation

To install, place the GameData folder inside your Kerbal Space Program folder.

**REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**.

### Dependencies

* Hard Dependencies
	+ [KSP API Extensions/L](https://github.com/net-lisias-ksp/KSPAPIExtensions) 2.1 or later

### Licensing

* Retractable Lifting Surface is double licensed as follows:
	+ [SKL 1.0](https://ksp.lisias.net/SKL-1_0.txt). See [here](./LICENSE.KSPe.SKL-1_0)
		+ You are free to:
			- Use : unpack and use the material in any computer or device
			- Redistribute : redistribute the original package in any medium
		+ Under the following terms:
			- You agree to use the material only on (or to) KSP
			- You don't alter the package in any form or way (but you can embedded it)
			- You don't change the material in any way, and retain any copyright notices
			- You must explicitly state the author's Copyright, as well an Official Site for downloading the original and new versions (the one you used to download is good enough)
	+ [GPL 2.0](https://www.gnu.org/licenses/gpl-2.0.txt). See [here](./LICENSE.KSPe.GPL-2_0)
		+ You are free to:
			- Use : unpack and use the material in any computer or device
			- Redistribute : redistribute the original package in any medium
			- Adapt : Reuse, modify or incorporate source code into your works (and redistribute it!) 
		+ Under the following terms:
			- You retain any copyright notices
			- You recognise and respect any trademarks
			- You don't impersonate the authors, neither redistribute a derivative that could be misrepresented as theirs.
			- You credit the author and republish the copyright notices on your works where the code is used.
			- You relicense (and fully comply) your works using GPL 2.0
			- You don't mix your work with GPL incompatible works.
	* If by some reason the GPL would be invalid for you, rest assured that you still retain the right to Use the Work under SKL 1.0. 

Releases previous to 0.2.2 are still available under the MIT license [here](https://github.com/net-lisias-kspu/RetractableLiftingSurface/tree/Source/MIT) and on the in upstream's repositories. Please note this [statement](https://www.gnu.org/licenses/license-list.en.html#Expat) from FSF.

Please note the copyrights and trademarks in [NOTICE](./NOTICE).


## UPSTREAM

* [LinuxGuruGamer](https://forum.kerbalspaceprogram.com/index.php?/profile/129964-linuxgurugamer/) ROOT
	+ [Forum](https://forum.kerbalspaceprogram.com/index.php?/topic/145583-15x-retractableliftingsurface-module-released/)
	+ [GitHub](https://github.com/linuxgurugamer/RetractableLiftingSurface)
