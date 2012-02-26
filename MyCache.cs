using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyThreadSafeCache
{
    sealed class MyCache : TinyThreadSafeCache<MyTypeToCache>
    {
        //singleton private instance
        private static readonly MyCache _instance = new MyCache();

        private MyCache() { } // Make sure only us can call constructor

        public static MyCache Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
