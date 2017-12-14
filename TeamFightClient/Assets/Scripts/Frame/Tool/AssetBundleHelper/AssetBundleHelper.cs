/*
 * FileName:     AssetBundleHelper 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZW.CourseEditor;
using System;

namespace ZW.Frame
{
	public class AssetBundleHelper
	{
        //private string BundleURL = "file:///D:/AssetBundle/lab_scene.assetbundle";
        //private string SceneURL = "file:///D:/AssetBundle/scene1";

        public static void LoadAssetBundle(MonoBehaviour mono, string bundlePath, string assetName, Action<GameObject> callback)
        {
            mono.StartCoroutine(DownloadAsset(bundlePath, assetName, callback));
        }

        private static IEnumerator DownloadAsset(string bundlePath, string assetName, Action<GameObject> callback)
        {
            //下载assetbundle，加载Cube  
            using (WWW asset = new WWW(bundlePath))
            {
                yield return asset;

                AssetBundle bundle = asset.assetBundle;
                UnityEngine.Object obj = bundle.LoadAsset(assetName);

                GameObject go = GameObject.Instantiate(obj) as GameObject;

                bundle.Unload(false);

                if (callback != null)
                {
                    callback.Invoke(go);
                }
            }

        }
    }

}
