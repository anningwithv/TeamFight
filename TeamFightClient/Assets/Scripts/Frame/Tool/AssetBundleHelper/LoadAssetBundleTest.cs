/*
 * FileName:     LoadAssetBundleTest 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ZW.Frame;
using System;

namespace ZW.CourseEditor
{
	public class LoadAssetBundleTest : ManagerBase
	{
        //private string BundleURL = "file:///D:/AssetBundle/lab_scene.assetbundle";
        //private string SceneURL = "file:///D:/AssetBundle/scene1";

        private string BundleURL;

        void Start()
        {
            //BundleURL = DataHelper.AssetBundleSavePath + "/lab_scene.assetbundle";

            //Debug.Log(BundleURL);

            //DoWithDelay.Do(this, 1.0f, () => {
            //    SendMsg(new MsgAssetBundleInfo((int)(AssetBundleManager.MsgType.OnLoadAsset),
            //        BundleURL, "lab_scene"));
            //});

        }

        IEnumerator DownloadAssetAndScene()
        {
            //下载assetbundle，加载Cube  
            using (WWW asset = new WWW(BundleURL))
            {
                yield return asset;
                AssetBundle bundle = asset.assetBundle;
                UnityEngine.Object obj = bundle.LoadAsset("lab_scene");
                Instantiate(obj);
                bundle.Unload(false);
                yield return new WaitForSeconds(5);
            }
            ////下载场景，加载场景  
            //using (WWW scene = new WWW(SceneURL))
            //{
            //    yield return scene;
            //    AssetBundle bundle = scene.assetBundle;
            //    SceneManager.LoadScene("scene1");
            //}

        }

        public override void ProcessMessage(MessageBase tmpMsg)
        {
            //throw new NotImplementedException();
        }
    }

}
