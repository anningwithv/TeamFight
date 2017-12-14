/*
 * FileName:     FrameTools 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description: 提供消息框架的一些工具方法
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.Frame
{
    public enum ManagerId
    {
        None = -1,
        UIManager = 0,
        GameManager = FrameTools.MSG_SPAN,
        InputManager = FrameTools.MSG_SPAN*2,
        OPManager = FrameTools.MSG_SPAN * 3,
        AssetBundleManager = FrameTools.MSG_SPAN * 4,
        PhotonManager = FrameTools.MSG_SPAN * 5,
    }

	public class FrameTools
	{
        public const int MSG_SPAN = 5000;
	}
}
