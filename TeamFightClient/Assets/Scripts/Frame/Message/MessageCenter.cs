/*
 * FileName:     MessageCenter 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:  不同Manager之间的消息中转站
 *
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.Frame
{
	public class MessageCenter : MonoBase
	{
        public static MessageCenter Instance = null;

        private void Awake()
        {
            Instance = this;
        }

        public override void ProcessMessage(MessageBase tmpMsg)
        {
            AnalysisMsg(tmpMsg);
        }

        public void SendToMsg(MessageBase tmpMsg)
        {
        }

        private void AnalysisMsg(MessageBase tmpMsg)
        {
            ManagerId tmpId = tmpMsg.GetManager();
            ManagerBase manager = GetManager(tmpId);
            if (manager != null)
            {
                manager.ProcessMessage(tmpMsg);
            }
        }

        private ManagerBase GetManager(ManagerId id)
        {
            var managers = FindObjectsOfType<ManagerBase>();
            foreach (ManagerBase manager in managers)
            {
                if (manager.m_managerId == id)
                {
                    return manager;
                }
            }

            return null;
        }
    }

}
