NBootstrap
=====

A simple, flexible application bootstrapper.

Usage:
--------

```C#


	Bootstrapper.Run(serviceLocator, () => new[] { typeof(BoostrapTask1), typeof(BootstrapTask2), });
	
```


License & Copyright
=====

This software is released under the GNU Lesser GPL. It is Copyright 2012, Ben Aston. I may be contacted at ben@bj.ma.