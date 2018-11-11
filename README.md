# RetractableLiftingSurface /L Unofficial

This is a small module which allows you to have a folding wing or other retractable lifting surface. Unofficial fork by Lisias.


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


## Installation

To install, place the GameData folder inside your Kerbal Space Program folder.

**REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**.

### Dependencies

* Hard Dependencies
	+ [KSP API Extensions/L](https://github.com/net-lisias-ksp/KSPAPIExtensions) 2.1 or later

### Licensing
This work is licensed under [MIT](https://opensource.org/licenses/MIT). See [here](./LICENSE).

Please note the copyrights and trademarks in [NOTICE](./NOTICE).


## UPSTREAM

* [LinuxGuruGamer](https://forum.kerbalspaceprogram.com/index.php?/profile/129964-linuxgurugamer/) ROOT
	+ [Forum](https://forum.kerbalspaceprogram.com/index.php?/topic/145583-15x-retractableliftingsurface-module-released/)
	+ [GitHub](https://github.com/linuxgurugamer/RetractableLiftingSurface)
