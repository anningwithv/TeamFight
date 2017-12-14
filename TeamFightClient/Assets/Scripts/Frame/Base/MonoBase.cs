/*
 * FileName:     MonoBase 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:  抽象类，所有需要处理消息的类的基类，提供公共方法，方便修改
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.Frame
{
	public abstract class MonoBase : MonoBehaviour
	{
        /// <summary>
        /// 处理消息事件
        /// </summary>
        /// <param name="tmpMsg"></param>
        public abstract void ProcessMessage(MessageBase tmpMsg);
	}

}
