# tinythreadsafecache

A threadsafe generic cache in C#. This is a very simple implementation that let you create a cache for any type of objects on the fly without worrying about threading issues.

The class is simply a wrapper around a dictionary keyed by strings. All the access point have been protected by a read/write lock to improve performance in a multi-threaded environment.

I did not bother making it a library since it is only a class; the sources contain a sample project using the class. To use the cache , you really only need to download the class.

In most of the projects that I use this class, I derive the class as a singleton so I can access my cache from anywhere. Initially I had made the class a singleton however, I realized that it might not fit every person's needs so I left it out of the class implementation.

There is an example of how to derive it as a singleton in the Documentation page : [Documentation](https://github.com/KurdyMalloy/tinythreadsafecache/wiki/Documentation).
