using System.Collections;
using System.Collections.Generic;
using TeamFightCommon.Model;
using UnityEngine;
using UnityEngine.UI;
using ZW.Frame;

public class LoginPanel : UIPanelBase
{
    public Button m_btnLogin = null;
    public InputField m_ifUserName = null;
    public InputField m_ifPassword = null;

    private void Start()
    {
        m_btnLogin.onClick.AddListener(delegate() 
        {
            Debug.Log("Login btn clicked.");

            string name = m_ifUserName.text;
            string password = m_ifPassword.text;
            
            User ui = new User() { Username = name, Password = password};
            SendMsg(new MsgLogin((int)PhotonManager.MsgType.Login, ui));

            MainPanel.Instance.OnLogin();
        });
    }
}
