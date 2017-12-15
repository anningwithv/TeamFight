using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZW.Frame;

public class PhotonItemBase : MonoBase
{
    public void RegistSelf(MonoBase mono, params int[] msgs)
    {
        PhotonManager.Instance.RegistMsg(mono, msgs);
    }

    public void UnRegistSelf(MonoBase mono, params int[] msgs)
    {
        PhotonManager.Instance.UnRegistMsg(mono, msgs);
    }

    public void SendMsg(MessageBase msg)
    {
        PhotonManager.Instance.SendMsg(msg);
    }

    public override void ProcessMessage(MessageBase tmpMsg)
    {
    }
}
