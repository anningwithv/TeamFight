/*
 * FileName:     FileHelper 
 * Author:       W.Z
 * CreateTime:   #CREATETIME#
 * Description:
 *
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace ZW.Frame
{
	public class FileHelper
	{
        public static void WriteFile(string path, string content, bool append = true)
        {
            StreamWriter sw;

            if (!File.Exists(path))
            {
                sw = File.CreateText(path);
                Debug.Log("File created : " + path);
            }
            else
            {
                if (append)
                {
                    sw = File.AppendText(path);
                }
                else
                {
                    sw = File.CreateText(path);
                }
            }

            sw.WriteLine(content);

            sw.Close();
            sw.Dispose();
        }

        public static string ReadFile(string path)
        {
            StreamReader sr;
            if (File.Exists(path))
            {
                sr = File.OpenText(path);
            }
            else
            {
                Debug.LogError("Read file but can't find files!");
                return string.Empty;
            }

            string content = sr.ReadToEnd();

            sr.Close();
            sr.Dispose();

            return content;
        }
    }
}
