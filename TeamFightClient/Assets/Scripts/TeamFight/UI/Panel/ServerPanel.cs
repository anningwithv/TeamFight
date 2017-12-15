using System.Collections;
using System.Collections.Generic;
using TeamFightCommon.Model;
using UnityEngine;
using UnityEngine.UI;
using ZW.Frame;

public class ServerPanel : UIPanelBase
{
    public Transform m_content = null;
    public GameObject m_serverItemPrefab = null;

    private void Start()
    {
        RegistSelf(this, (int)UIManager.MsgType.OnGetServerList);
    }

    public override void ProcessMessage(MessageBase tmpMsg)
    {
        if (tmpMsg.m_msgId == (int)UIManager.MsgType.OnGetServerList)
        {
            MsgServerList msgServerList = (MsgServerList)tmpMsg;
            if (msgServerList != null)
            {
                SpawnServerItems(msgServerList.serverList);
            }
            else
            {
                Debug.LogError("Convert msg to MsgServerList error.");
            }
        }
    }

    private void SpawnServerItems(List<ServerProperty> serverList)
    {
        foreach (ServerProperty sp in serverList)
        {
            GameObject item = Instantiate(m_serverItemPrefab, m_content);
            ServerItem serverItem = item.GetComponent<ServerItem>();
            if (serverItem != null)
            {
                serverItem.SetContent(sp.Name, sp.Count.ToString());
            }
        }
    }

}
