using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ZW.Frame
{
    /// <summary>
    /// 泛型单利类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Singleton<T> where T : class, new()
    {
        private static T Instance;
        private static readonly object syslock = new object();

        public static T GetInstance()
        {
            if (Instance == null)
            {
                lock (syslock)
                {
                    if (Instance == null)
                    {
                        Instance = new T();
                    }
                }
            }
            return Instance;
        }
    }
}
