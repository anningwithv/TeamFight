using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TeamFightCommon;
using ZW.Frame;

public class PhotonEngine : PhotonItemBase, IPhotonPeerListener
{
    public ConnectionProtocol protocol = ConnectionProtocol.Tcp;

    private string serverAddress = "127.0.0.1:4530";
    private string applicationName = "TeamFightServer";

    private static PhotonEngine _instance;
    private PhotonPeer peer;

    private Dictionary<byte, ControllerBase> m_controllers = new Dictionary<byte, ControllerBase>();

    public static PhotonEngine Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        peer = new PhotonPeer(this, protocol);
        peer.Connect(serverAddress, applicationName);
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (peer != null)
            peer.Service();
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log("DebugReturn : " + level + ":" + message);
    }

    public void OnEvent(EventData eventData)
    {
        Debug.Log("OnEvent : " + eventData.ToString());
    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        Debug.Log("OnOperationResponse : " + operationResponse.OperationCode);

        ControllerBase controller;
        m_controllers.TryGetValue(operationResponse.OperationCode, out controller);
        if (controller != null)
        {
            controller.OnOperationResponse(operationResponse);
        }
        else
        {
            Debug.LogWarning("Receive a unknown response . OperationCode :" + operationResponse.OperationCode);
        }
    }

    public void OnStatusChanged(StatusCode statusCode)
    {
        Debug.Log("OnStatusChanged : " + statusCode.ToString());
        switch (statusCode)
        {
            case StatusCode.Connect:
                SendMsg(new MessageBase((int)UIManager.MsgType.OnConnectedToServer));
                break;
        }
    }

    public void RegisterController(OperationCode opCode, ControllerBase controller)
    {
        m_controllers.Add((byte)opCode, controller);
    }

    public void UnRegisterController(OperationCode opCode)
    {
        m_controllers.Remove((byte)opCode);
    }

    public void SendRequest(OperationCode opCode, Dictionary<byte, object> parameters)
    {
        Debug.Log("sendrequest to server , opcode : " + opCode);
        peer.OpCustom((byte)opCode, parameters, true);
    }
}
