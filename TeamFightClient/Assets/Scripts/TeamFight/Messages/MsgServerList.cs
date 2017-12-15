using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZW.Frame;
using TeamFightCommon.Model;

public class MsgServerList : MessageBase
{
    public List<ServerProperty> serverList;

    public MsgServerList(int msgId, List<ServerProperty> serverList) : base(msgId)
    {
        this.serverList = serverList;
    }
}
