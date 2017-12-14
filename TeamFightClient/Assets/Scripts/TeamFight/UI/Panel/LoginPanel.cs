using System.Collections;
using System.Collections.Generic;
using TeamFightCommon.Model;
using UnityEngine;
using UnityEngine.UI;
using ZW.Frame;

public class LoginPanel : UIPanelBase
{
    public Button m_btnLogin = null;

    private void Start()
    {
        m_btnLogin.onClick.AddListener(delegate() 
        {
            Debug.Log("Login btn clicked.");

            User ui = new User();
            SendMsg(new MsgLogin((int)PhotonManager.MsgType.Login, ui));
        });
    }
}
