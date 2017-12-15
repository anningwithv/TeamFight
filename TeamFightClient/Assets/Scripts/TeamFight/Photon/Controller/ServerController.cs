using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using TeamFightCommon;
using UnityEngine;
using TeamFightCommon.Model;
using LitJson;
using ZW.Frame;

public class ServerController : ControllerBase
{
    public override void Start()
    {
        base.Start();

        RegistSelf(this, (int)PhotonManager.MsgType.OnLoginSuccess);
    }

    public override OperationCode OpCode
    {
        get { return OperationCode.GetServer; }
    }

    private void GetServerList()
    {
        PhotonEngine.Instance.SendRequest(OperationCode.GetServer, new Dictionary<byte, object>());
    }

    public override void OnOperationResponse(OperationResponse response)
    {
        if (response.ReturnCode == (short)ReturnCode.Success)
        {
            Debug.Log("Get server success");

            Dictionary<byte, object> parameters = response.Parameters;
            object jsonObject = null;
            parameters.TryGetValue((byte)ParameterCode.ServerList, out jsonObject);
            List<ServerProperty> serverList = JsonMapper.ToObject<List<ServerProperty>>(jsonObject.ToString());

            // send msg to refresh ui
            SendMsg(new MsgServerList((int)UIManager.MsgType.OnGetServerList, serverList));
        }
        else if (response.ReturnCode == (short)ReturnCode.Fail)
        {
            Debug.Log("Get server Fail");
        }
        else if (response.ReturnCode == (short)ReturnCode.Error)
        {
            Debug.Log("Get server Error");
        }
    }

    public override void ProcessMessage(MessageBase tmpMsg)
    {
        if (tmpMsg.m_msgId == (int)PhotonManager.MsgType.OnLoginSuccess)
        {
            GetServerList();
        }
    }

}
