/*
 * FileName:     ManagerBase 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description: 所有Manager类的基类，存储该Manager管辖下的所有消息
 *
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.Frame
{
	public class ManagerBase : MonoBase
	{
        public ManagerId m_managerId;

        // 用于存储所有注册的消息
        private Dictionary<int, List<MessageNode>> m_eventTree = new Dictionary<int, List<MessageNode>>();

        /// <summary>
        /// 用于一个mono注册多个消息
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="msgIds"></param>
        public void RegistMsg(MonoBase mono, params int[] msgIds)
        {
            for (int i = 0; i < msgIds.Length; i++)
            {
                MessageNode tmp = new MessageNode(mono);
                RegistMsg(msgIds[i], tmp);
            }
        }

        /// <summary>
        /// 用于一个mono注销多个消息
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="msgIds"></param>
        public void UnRegistMsg(MonoBase mono, params int[] msgIds)
        {
            for (int i = 0; i < msgIds.Length; i++)
            {
                UnRegistMsg(msgIds[i], mono);
            }
        }

        /// <summary>
        /// 用于某个消息注册一个mono(Node)
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="node"></param>
        public void RegistMsg(int msgId, MessageNode node)
        {
            if (!m_eventTree.ContainsKey(msgId))
            {
                List<MessageNode> list = new List<MessageNode>();
                list.Add(node);
                m_eventTree.Add(msgId, list);
            }
            else
            {
                List<MessageNode> list = new List<MessageNode>();
                m_eventTree.TryGetValue(msgId, out list);
                list.Add(node);
            }
        }

        /// <summary>
        /// 用于某个消息注销一个mono(Node)
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="node"></param>
        public void UnRegistMsg(int msgId, MonoBase node)
        {
            if (!m_eventTree.ContainsKey(msgId))
            {
                return;
            }
            else
            {
                List<MessageNode> list = new List<MessageNode>();
                m_eventTree.TryGetValue(msgId, out list);

                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i].data == node)
                    {
                        list.Remove(list[i]);
                    }
                }
            }
        }

        /// <summary>
        /// 发送一个消息，如果消息是Manager内部消息，则直接转发给监听者。如果是跨Manager间的消息，
        /// 则发送给MessageCenter,来转发给相应的Manager
        /// </summary>
        /// <param name="msg"></param>
        public void SendMsg(MessageBase msg)
        {
            if (msg.GetManager() == m_managerId)
            {
                ProcessMessage(msg);
            }
            else
            {
                MessageCenter.Instance.ProcessMessage(msg);
            }
        }

        /// <summary>
        /// 处理消息：当某个mono发送了消息后，消息会被发送到对应的Manager,
        /// 调用ProcessEvent方法将该消息转发给相应的监听者
        /// </summary>
        /// <param name="tmpMsg"></param>
        public override void ProcessMessage(MessageBase tmpMsg)
        {
            if (!m_eventTree.ContainsKey(tmpMsg.m_msgId))
            {
                Debug.LogError("Msg id does not exit in event tree : " + tmpMsg.m_msgId + 
                    " Manager id is ： " + m_managerId.ToString());
            }
            else
            {
                List<MessageNode> list = new List<MessageNode>();
                m_eventTree.TryGetValue(tmpMsg.m_msgId, out list);

                foreach (MessageNode node in list)
                {
                    if (node.data == this) // 如果是manager自己的消息 则自己处理
                    {
                        ((ManagerBase)(node.data)).ProcessSelfMessage(tmpMsg);
                    }
                    else // manager管辖内 其他mono注册的消息，则分发给相应的Mono处理
                    {
                        node.data.ProcessMessage(tmpMsg);
                    }

                }
            }
        }

        protected virtual void ProcessSelfMessage(MessageBase msg)
        {

        }
    }

}
