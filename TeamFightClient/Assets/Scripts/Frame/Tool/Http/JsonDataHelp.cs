using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using System.Web.Script.Serialization;
using UnityEngine;

namespace ZW.Frame
{
	class JsonDataHelp
	{
		private static JsonDataHelp _jsonDataHelper = null;
	
	    public static JsonDataHelp getInstance()
	    {
			if (_jsonDataHelper == null) {
				_jsonDataHelper = new JsonDataHelp ();
			}
	
			return _jsonDataHelper;
	    }
	
	    //private JavaScriptSerializer _serializer = new JavaScriptSerializer();
	
	    public T JsonDeserialize<T>(string jsondata)
	    {
	        //T v = _serializer.Deserialize<T>(jsondata);
			T v = JsonUtility.FromJson<T>(jsondata);
	        return v;
	    }
	
	    public string JsonSerialize<T>(T jsonobjectdata)
	    {
	        //string v = _serializer.Serialize(jsonobjectdata);
			string v = JsonUtility.ToJson(jsonobjectdata);
	        return v;
	    }
//		public static JsonDataHelp getInstance()
//		{
//			return Singleton<JsonDataHelp>.getInstance();
//		}
//
//		private JavaScriptSerializer _serializer = new JavaScriptSerializer();
//
//		public T JsonDeserialize<T>(string jsondata)
//		{
//			T v = _serializer.Deserialize<T>(jsondata);
//
//			return v;
//		}
//
//		public string JsonSerialize<T>(T jsonobjectdata)
//		{
//			string v = _serializer.Serialize(jsonobjectdata);
//
//			return v;
//		}
	}
}
