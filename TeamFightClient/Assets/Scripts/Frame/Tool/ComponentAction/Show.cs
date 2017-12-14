/*
 * FileName:     Show 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZW.Frame
{
	public class Show : MonoBehaviour
	{
        public void Action(bool show)
        {
            gameObject.SetActive(show);
        }
    }

}
