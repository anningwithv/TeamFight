using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using TeamFightCommon;
using UnityEngine;
using TeamFightCommon.Model;
using LitJson;

public class LoginController : ControllerBase
{
    public override OperationCode OpCode
    {
        get { return OperationCode.Login; }
    }

    public void Login(User user)
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
}
