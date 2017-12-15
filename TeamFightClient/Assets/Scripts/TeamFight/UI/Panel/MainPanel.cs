using System.Collections;
using System.Collections.Generic;
using TeamFightCommon.Model;
using UnityEngine;
using UnityEngine.UI;
using ZW.Frame;

public class MainPanel : UIPanelBase
{
    public static MainPanel Instance = null;

    public LoginPanel m_panelLogin = null;
    public ServerPanel m_pandelServer = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RegistSelf(this, (int)UIManager.MsgType.OnConnectedToServer);

        m_panelLogin.gameObject.SetActive(false);
        m_pandelServer.gameObject.SetActive(false);
    }

    public override void ProcessMessage(MessageBase tmpMsg)
    {
        if (tmpMsg.m_msgId == (int)UIManager.MsgType.OnConnectedToServer)
        {
            m_panelLogin.gameObject.SetActive(true);
        }
    }

    public void OnLogin()
    {
        m_panelLogin.gameObject.SetActive(false);
        m_pandelServer.gameObject.SetActive(true);
    }
}
