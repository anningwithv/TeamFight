using UnityEngine;
using System.Collections;
using ExitGames.Client.Photon;
using TeamFightCommon;
using ZW.Frame;

public abstract class ControllerBase : PhotonItemBase
{
    public abstract OperationCode OpCode { get; }

    public virtual void Start()
    {
        PhotonEngine.Instance.RegisterController(OpCode, this);
    }

    public virtual void OnDestroy()
    {
        PhotonEngine.Instance.UnRegisterController(OpCode);
    }
    public virtual void OnEvent(EventData eventData)
    {

    }

    public abstract void OnOperationResponse(OperationResponse response);

}
