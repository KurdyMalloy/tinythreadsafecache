using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyThreadSafeCache
{
    sealed class MyCache
    {
        //singleton private instance
        private static readonly TinyThreadSafeCache<MyTypeToCache> _instance = new TinyThreadSafeCache<MyTypeToCache>();

        private MyCache() { } // Make sure only us can call constructor

        public static TinyThreadSafeCache<MyTypeToCache> Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
