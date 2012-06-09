NBootstrap
=====

A simple, flexible application bootstrapper.

Usage:
--------

```C#


	Bootstrapper.Run(serviceLocator, () => new[] { typeof(BoostrapTask1), typeof(BootstrapTask2), });
	
```


How to build and/or run the tests:
--------

1. Run `/build/build.bat`
1. Type in the desired option
1. Hit return

License & Copyright
--------

This software is released under the GNU Lesser GPL. It is Copyright 2012, Ben Aston. I may be contacted at ben@bj.ma.

How to Contribute
--------

Pull requests including bug fixes, new features and improved test coverage are welcomed. Please do your best, where possible, to follow the style of code found in the existing codebase.