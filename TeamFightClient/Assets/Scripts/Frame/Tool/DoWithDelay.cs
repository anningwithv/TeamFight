/*
 * FileName:     DoWithDelay 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:  工具类，延时操作
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.Frame
{
	public class DoWithDelay
	{
        public static void Do(MonoBehaviour mono, float delay, System.Action action)
        {
            mono.StartCoroutine(DoCor(delay, action));
        }

        private static IEnumerator DoCor(float delay, System.Action action)
        {
            yield return new WaitForSeconds(delay);

            if (action != null)
            {
                action.Invoke();
            }
        }
	}

}
