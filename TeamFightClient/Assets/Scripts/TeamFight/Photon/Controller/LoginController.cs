using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using TeamFightCommon;
using UnityEngine;
using TeamFightCommon.Model;
using LitJson;
using ZW.Frame;

public class LoginController : ControllerBase
{
    public override OperationCode OpCode
    {
        get { return OperationCode.Login; }
    }

    public override void Start()
    {
        base.Start();

        RegistSelf(this, (int)PhotonManager.MsgType.Login);
    }

    private void Login(User user)
    {
        string json = JsonMapper.ToJson(user);
        Dictionary<byte, object> parameters = new Dictionary<byte, object>();
        parameters.Add((byte)ParameterCode.User, json);
        PhotonEngine.Instance.SendRequest(OperationCode.Login, parameters);
    }

    public override void OnOperationResponse(OperationResponse response)
    {
        if (response.ReturnCode == (short)ReturnCode.Success)
        {
            Debug.Log("Login success");
            SendMsg(new MessageBase((int)PhotonManager.MsgType.OnLoginSuccess));
        }
        else if (response.ReturnCode == (short)ReturnCode.Fail)
        {
            Debug.Log("Login Fail");
        }
        else if (response.ReturnCode == (short)ReturnCode.Error)
        {
            Debug.Log("Login Error");
        }
    }

    public override void ProcessMessage(MessageBase tmpMsg)
    {
        if (tmpMsg.m_msgId == (int)PhotonManager.MsgType.Login)
        {
            MsgLogin msgLogin = (MsgLogin)tmpMsg;
            if (msgLogin != null)
            {
                Login(msgLogin.user);
            }
            else
            {
                Debug.LogError("Conver msg to MsgLogin error！");
            }
        }
    }
}
