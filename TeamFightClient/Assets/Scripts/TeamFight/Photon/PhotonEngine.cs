using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhotonEngine : MonoBehaviour,IPhotonPeerListener
{
    public ConnectionProtocol protocol = ConnectionProtocol.Tcp;
    private string serverAddress = "127.0.0.1:4530";
    private string applicationName = "TeamFightServer";

    private static PhotonEngine _instance;
    private PhotonPeer peer;

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
    }

    public void OnStatusChanged(StatusCode statusCode)
    {
        Debug.Log("OnStatusChanged : " + statusCode.ToString());
    }

}
