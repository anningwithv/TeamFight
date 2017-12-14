using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZW.Frame;

public class UIPanelBase : MonoBase
{
    public void RegistSelf(MonoBase mono, params int[] msgs)
    {
        UIManager.Instance.RegistMsg(mono, msgs);
    }

    public void UnRegistSelf(MonoBase mono, params int[] msgs)
    {
        UIManager.Instance.UnRegistMsg(mono, msgs);
    }

    public void SendMsg(MessageBase msg)
    {
        UIManager.Instance.SendMsg(msg);
    }

    public override void ProcessMessage(MessageBase tmpMsg)
    {
    }
}
