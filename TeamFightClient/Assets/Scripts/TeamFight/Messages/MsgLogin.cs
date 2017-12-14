using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZW.Frame;
using TeamFightCommon.Model;

public class MsgLogin : MessageBase
{
    public User user = null;

    public MsgLogin(int mgsId, User user) : base(mgsId)
    {
        this.user = user;
    }
}
