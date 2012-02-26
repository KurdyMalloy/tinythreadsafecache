using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TinyThreadSafeCache
{

    /// <summary>
    /// This is a generic cache that is thread safe and uses a read/write lock access for performance.
    /// The cache itself is a string key based dictionary.
    /// </summary>
    /// <typeparam name="T">The type that we want to keep in the cache</typeparam>
    public class TinyThreadSafeCache<T>
    {
        protected ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim(); // mutex 
        protected Dictionary<string, T> innerCache = new Dictionary<string, T>();  // the cache itself

        // This method will replace existing item or add if it does not already exist
        public void Add(string key, T val)
        {
            cacheLock.EnterWriteLock();
            try
            {
                innerCache[key] = val;
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        // This is to get an item from the cache by its key, it will return null if not found.
        public T Get(string key)
        {
            cacheLock.EnterReadLock();
            try
            {
                T val;
                innerCache.TryGetValue(key, out val); // So there is no exception if not found
                return val;
            }
            finally
            {
                cacheLock.ExitReadLock();
            }
        }

        // This method is to remove an item from the cache by its key
        public void Delete(string key)
        {
            cacheLock.EnterWriteLock();
            try
            {
                innerCache.Remove(key);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        // This method empty the whole cache.
        public void Purge()
        {
            cacheLock.EnterWriteLock();
            try
            {
                innerCache.Clear();
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        // This method validates that a key exists in the cache.
        public bool Exist(string key)
        {
            cacheLock.EnterReadLock();
            try
            {
                return innerCache.ContainsKey(key);
            }
            finally
            {
                cacheLock.ExitReadLock();
            }
        }

        // This methods gets the number of items saved in the cache.
        public int Size()
        {
            cacheLock.EnterReadLock();
            try
            {
                return innerCache.Count;
            }
            finally
            {
                cacheLock.ExitReadLock();
            }
        }

    }
}
