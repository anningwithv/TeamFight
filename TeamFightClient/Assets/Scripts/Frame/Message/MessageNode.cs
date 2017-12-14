/*
 * FileName:     MessageNode 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:  注册消息时 注册对象的句柄
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.Frame
{
	public class MessageNode
	{
        public MonoBase data;

        public MessageNode(MonoBase tmpMono)
        {
            this.data = tmpMono;
        }
	}

}
