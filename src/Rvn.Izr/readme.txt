# rvn-izr

Head onto [rv-izr project site](https://github.com/dgg/rvn-izr) for more information.

## What is rvn-izr

_rvn-izr_ is a set of utilities, better practices and patterns that I found useful when working with RavenDB.

## What was installed?

_rvn-izr_ is made up of two major pieces:

* the __Rvn-Izr__ assembly that got referenced
* some helper classes that were added as c# code in the __Infrastructure/Data/Adapters/__ sub-folder of your project

### Do I need the source code?

As a matter of fact not every user of _rvn-izr_ needs those. The code is only needed when multiple databases are needed.

So, if you are not using multiple databases (or even if you do and have found your own sweet spot) you can safely delete those classes and go on with the binary benefits**

### How do I use the source code?

Jut delegate every member implementation to the ```_session``` field.

_Resharper_ users have it very easy:

1. hover the red squigly code
2. Show available quick-fixes and context actions (Alt-Enter)
3. Delegate implementation to _sessions field
4. Enjoy the time you saved

### Why source code?

Source code was chosen for the sole purpose of not depending of breaking API changes in _RavenDB.Client_.

For instance, the ```IDocumentSession``` interface (which is proposed to be implemented) has changed while on 2.5.x version. Having a binary dependency would have led us to multiple packages with different dependency requirements.

Instead, we push the responsability of implementing it to the user of our package: a developer, who is already using a given version of the dependency. And that, as we have seen, is not much of a burden.