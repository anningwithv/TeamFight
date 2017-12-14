/*
 * FileName:     MessageBase 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description: 所有消息类的基类,发送的实际消息
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.Frame
{
	public class MessageBase
	{
        public int m_msgId;

        public MessageBase(int mgsId)
        {
            this.m_msgId = mgsId;
        }

        public ManagerId GetManager()
        {
            int tempId = m_msgId / FrameTools.MSG_SPAN;
            return(ManagerId)(tempId * FrameTools.MSG_SPAN);
        }
    }
}
