NBootstrap
=====

A simple, flexible application bootstrapper.

Usage:
--------

```C#


	Bootstrapper.Run(serviceLocator, () => new[] { typeof(BoostrapTask1), typeof(BootstrapTask2), });
	
```
