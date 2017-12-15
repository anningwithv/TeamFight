using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZW.Frame;

public class PhotonManager : ManagerBase
{
    public enum MsgType
    {
        Login = ManagerId.PhotonManager + 1,
        OnLoginSuccess,
    }

    public static PhotonManager Instance = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //RegistMsg(this, (int)MsgType.Login);    
    }

    protected override void ProcessSelfMessage(MessageBase msg)
    {
        //if (msg.m_msgId == (int)MsgType.Login)
        //{
        //    MsgLogin msgLogin = (MsgLogin)msg;
        //    if (msgLogin != null)
        //    {
        //        FindObjectOfType<LoginController>().Login(msgLogin.user);
        //    }
        //    else
        //    {
        //        Debug.LogError("Conver msg to MsgLogin error！");
        //    }
        //}
    }
}
