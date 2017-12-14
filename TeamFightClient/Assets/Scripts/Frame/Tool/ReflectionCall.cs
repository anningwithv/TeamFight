/*
 * FileName:     ReflectionCall 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:  利用反射机制调用方法
 *
*/

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


namespace ZW.Frame
{
	public class ReflectionCall
	{
        public static List<string> strList = new List<string>();

        private static bool is_state = false;

        /// <summary>
        /// 反射机制调用方法
        /// </summary>
        /// <param name="classname"> 如果在不同的包下，classname需要包含包名</param>
        /// <param name="methed"></param>
        /// <param name="obj"></param>
        public static void CallMethod(string classname, string methed, object[] obj)
        {
            Assembly.GetExecutingAssembly().GetType(classname).GetMethod(methed).Invoke(null, obj);
        }
    }

}
