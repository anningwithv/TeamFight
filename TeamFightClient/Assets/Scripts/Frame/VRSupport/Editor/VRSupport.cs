/*
 * FileName:     MultiInputManager 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace HengDian.Frame
{
    public enum Platform
    {
        PC_VIVE = 0,
        PC_KEYBOARD = 1
    }
    public class VRSupport
    {
        public static Platform CurPlatform = Platform.PC_KEYBOARD;

        [MenuItem("ITools/Platform/Set Platform PC_VIVE")]
        private static void SetPlatformPC_VIVE()
        {
            CurPlatform = Platform.PC_VIVE;
            SaveSetting(CurPlatform);
            ResetVRSupported();
        }

        [MenuItem("ITools/Platform/Set Platform PC_KEYBOARD")]
        private static void SetPlatformPC_KEYBOARD()
        {
            CurPlatform = Platform.PC_KEYBOARD;
            SaveSetting(CurPlatform);
            ResetVRSupported();
        }

        private static void SaveSetting(Platform pf)
        {
            PlayerPrefs.SetInt("HD_Platform", (int)pf);
        }

        private static void ResetVRSupported()
        {
            if (CurPlatform == Platform.PC_VIVE)
            {
                if (PlayerSettings.virtualRealitySupported == false)
                {
                    PlayerSettings.virtualRealitySupported = true;
                }
            }
            else
            {
                if (PlayerSettings.virtualRealitySupported == true)
                {
                    PlayerSettings.virtualRealitySupported = false;
                }
            }
        }
    }

}
