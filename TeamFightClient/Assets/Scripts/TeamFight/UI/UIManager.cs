using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZW.Frame;

public class UIManager : ManagerBase
{
    public static UIManager Instance = null;

    public enum MsgType
    {        
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
    }
}
