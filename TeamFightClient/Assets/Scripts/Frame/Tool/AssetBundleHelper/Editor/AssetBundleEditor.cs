using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace HengDian.Frame
{
    public class AssetBundleEditor
    {
        [MenuItem("ITools/BuildAssetBundle")]
        public static void BuildAssetBundle()
        {
            string outPath = Application.dataPath + "/AssetBundle";
            BuildPipeline.BuildAssetBundles(outPath, 0, EditorUserBuildSettings.activeBuildTarget);

            AssetDatabase.Refresh();
        }

        [MenuItem("ITools/MarkAssetBundle")]
        public static void MarkAssetBundle()
        {
            AssetDatabase.RemoveUnusedAssetBundleNames();

            string path = Application.dataPath + "/Art/Scenes/";

            DirectoryInfo dir = new DirectoryInfo(path);
            FileSystemInfo[] fileInfo = dir.GetFileSystemInfos();
            for (int i = 0; i < fileInfo.Length; i++)
            {
                FileSystemInfo tempFile = fileInfo[i];
                if (tempFile is DirectoryInfo)
                {
                    string tmpPath = Path.Combine(path, tempFile.Name);
                    SceneOverView(tmpPath);
                }
            }

            AssetDatabase.Refresh();
        }

        /// <summary>
        /// 对整个场景文件夹遍历
        /// </summary>
        /// <param name="scenePath"></param>
        private static void SceneOverView(string scenePath)
        {
            // 创建一个text 记录名字对应关系
            string textFileName = "Record.text";
            string tmpPath = scenePath + textFileName;

            FileStream fs = new FileStream(tmpPath, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);

            Dictionary<string, string> readDict = new Dictionary<string, string>();

            ChangerHead(scenePath, readDict);

            foreach (string key in readDict.Keys)
            {
                sw.Write(key);
                sw.Write(" ");
                sw.Write(readDict[key]);
                sw.Write("\n");
            }

            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 截取相对路径
        /// </summary>
        private static void ChangerHead(string fullPath, Dictionary<string, string> theWriter)
        {
            int tmpCount = fullPath.IndexOf("Assets");
            int tmpLength = fullPath.Length;

            string replacePath = fullPath.Substring(tmpCount, tmpLength - tmpCount);
            DirectoryInfo dir = new DirectoryInfo(fullPath);
            Debug.Log("ChangerHead replacePath is: " + replacePath);
            if (dir != null)
            {
                ListFiles(dir, replacePath, theWriter);
            }
            else
            {
                Debug.Log("This path is not exist");
            }
        }

        /// <summary>
        /// 遍历场景文件夹中的每一个功能文件夹
        /// </summary>
        private static void ListFiles(FileSystemInfo info, string replacePath, Dictionary<string, string> theWriter)
        {
            if (!info.Exists)
            {
                Debug.Log("Is not exist");
                return;
            }

            DirectoryInfo dir = info as DirectoryInfo;

            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i] as FileInfo;

                if (file != null) //对于文件的操作
                {
                    ChangeMark(file, replacePath, theWriter);
                }
                else //对于目录的操作
                {
                    ListFiles(files[i], replacePath, theWriter);
                }
            }
        }

        /// <summary>
        /// 修改assetbundle标记
        /// </summary>
        /// <param name="tmpFile"></param>
        /// <param name="markStr"></param>
        /// <param name="theWriter"></param>
        private static void ChangeAssetMark(FileInfo tmpFile, string markStr, Dictionary<string, string> theWriter)
        {
            string fullPath = tmpFile.FullName;
            int assetCount = fullPath.IndexOf("Assets");
            string assPath = fullPath.Substring(assetCount, fullPath.Length - assetCount);

            AssetImporter importer = AssetImporter.GetAtPath(assPath);
            importer.assetBundleName = markStr;

            if (tmpFile.Extension == ".unity")
            {
                importer.assetBundleVariant = "u3d";
            }
            else
            {
                importer.assetBundleVariant = "ld";
            }

            string modelName = "";
            string[] subMark = markStr.Split("/".ToCharArray());
            if (subMark.Length > 1)
            {
                modelName = subMark[1];
            }
            else
            {
                modelName = markStr;
            }

            string modelPath = markStr.ToLower() + "." + importer.assetBundleVariant;
            if (!theWriter.ContainsKey(modelName))
            {
                theWriter.Add(modelName, modelPath);
            }
        }

        private static void ChangeMark(FileInfo tmpFile, string replacePath, Dictionary<string, string> theWriter)
        {
            if (tmpFile.Extension == ".meta")
            {
                return;
            }

            string markStr = GetBundlePath(tmpFile, replacePath);
            Debug.Log("ChangeMark markStr is: " + markStr);
            ChangeAssetMark(tmpFile, markStr, theWriter);
        }

        /// <summary>
        /// 计算mark标记值
        /// </summary>
        /// <param name="tmpFile"></param>
        /// <param name="replacePath"></param>
        /// <returns></returns>
        private static string GetBundlePath(FileInfo tmpFile, string replacePath)
        {
            Debug.Log("GetBundlePath replacePath is: " + replacePath);
            string tmpPath = tmpFile.FullName;
            Debug.Log("GetBundlePath tmpPath is: " + tmpPath);

            tmpPath = FixedPath(tmpPath);

            int assetCount = tmpPath.IndexOf(replacePath);
            assetCount += replacePath.Length + 1;
            int nameCount = tmpPath.LastIndexOf(tmpFile.Name);
            int tmpCount = replacePath.LastIndexOf("/");
            string sceneHead = replacePath.Substring(tmpCount + 1, replacePath.Length - tmpCount - 1);

            int tmpLength = nameCount - assetCount;
            if (tmpLength > 0)
            {
                string substring = tmpPath.Substring(assetCount, tmpPath.Length - assetCount);
                string[] result = substring.Split("/".ToCharArray());

                return sceneHead + "/" + result[0];
            }
            else
            {
                return sceneHead;
            }
        }

        private static string FixedPath(string path)
        {
            path = path.Replace("\\", "/");
            return path;
        }
    }
}