using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

[InitializeOnLoad]
public class ARMReferenceCache {

	static public bool IsLoaded;

	static ARMReferenceCache () {
	}

	public const string CacheDirectory = "ARMCache";
	public const string CacheFileName = "cache.db";

	static ARMReferenceTable cacheTable = null;


	static public bool IsIgnore (string path) {
		//		return true;
		//		if(Path.GetExtension(path) == "") return true;

		string extention = Path.GetExtension(path);
		foreach(string targetExtention in ARMSettings.Instance.targetExtensionList) {
			if(targetExtention == "") continue;
			if(extention == targetExtention) return false;
		}
		return true;
	}

	static public void ReImportAll () {

		cacheTable = new ARMReferenceTable();
		//		return;
		int count = 0;
		int Length = AssetDatabase.GetAllAssetPaths().Length;
		foreach(string path in AssetDatabase.GetAllAssetPaths()){
			count ++;
			if(IsIgnore(path)) continue;

			//			if(count%10 == 0)
			EditorUtility.DisplayProgressBar("参照関係確認中", ((float)count / Length * 100f).ToString("0") + " %", (float)count / Length);
			AnalyzeProperty(path);
		}
		EditorUtility.ClearProgressBar();
		IsLoaded = true;
	}

	public static void AnalyzeProperty (string path) {
		string guid = AssetDatabase.AssetPathToGUID(path);

		//参照一覧取得
		foreach(Object obj in AssetDatabase.LoadAllAssetsAtPath(path)){
			if(obj == null) continue;
			if(obj.name == "Deprecated EditorExtensionImpl") continue;
			SerializedObject sObj = new SerializedObject(obj);
			if(sObj == null) { sObj.Dispose(); continue;}

			SerializedProperty sProp = sObj.GetIterator();
			if(sProp ==  null) continue;
			int countRemaining = 0;
			while(sProp.Next(true)){
				countRemaining ++;
				if(sProp ==  null) continue;
				if(sProp.propertyType != SerializedPropertyType.ObjectReference) continue;
				if(sProp.objectReferenceValue == null) continue;

				string refPath = AssetDatabase.GetAssetPath(sProp.objectReferenceValue);
				string refGUID = AssetDatabase.AssetPathToGUID(refPath);
				if(refPath == path) continue;
				int instanceID = obj.GetInstanceID();

				ARMReferenceCache.AddReference(refGUID, new ARMCacheData(guid, instanceID, countRemaining));
			}
		}
		/*
		string ext = Path.GetExtension(path);
		//		Debug.Log(ext + "  " + path);
		if(ext==".prefab" || ext==".unity"){
			Debug.Log(ext + "  " + path);
			FileStream fs = new FileStream(Application.dataPath.Replace("Assets","")+path, FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			while(sr.Peek() >= 0){
				string line = sr.ReadLine();
				if(line.IndexOf("guid")!=-1)Debug.Log(line);
			}
			sr.Dispose();
			fs.Dispose();
		}
		*/
	}

	public static List<ARMCacheData> GetReferenceList (string keyGUID) {
		if(cacheTable == null) ReImportAll();

		if(cacheTable.GetTable().Keys.Contains(keyGUID)){
			return cacheTable.GetTable()[keyGUID];
		}else {
			return null;
		}
	}

	public static void SetReferenceList (string keyGUID, List<ARMCacheData> refDataList) {
		if(cacheTable == null) ReImportAll();

		if(cacheTable.GetTable().Keys.Contains(keyGUID)){
			cacheTable.GetTable()[keyGUID] = refDataList;
		}else {
			cacheTable.GetTable().Add(keyGUID, refDataList);
		}
	}

	public static void AddReference (string keyGUID, ARMCacheData refData) {
		if(cacheTable == null) ReImportAll();

		if(cacheTable.GetTable().Keys.Contains(keyGUID)){
			if(!ContainReference(keyGUID, refData)) {
				cacheTable.GetTable()[keyGUID].Add(refData);
			}
		}else {
			cacheTable.GetTable().Add(keyGUID, new List<ARMCacheData>(){refData});
		}
	}

	public static void RemoveReference (string keyGUID, string refGUID) {
		//		if(cacheTable == null) ReImportAll();
		if(cacheTable == null) return;

		if(cacheTable.GetTable().Keys.Contains(keyGUID)){
			ARMCacheData[] refGUIDs = cacheTable.GetTable()[keyGUID].Where(d=> d.refGUID == refGUID).ToArray();
			foreach(ARMCacheData data in refGUIDs){
				cacheTable.GetTable()[keyGUID].Remove(data);
			}
		}
	}
	public static void RemoveReference (string keyGUID, ARMCacheData refData) {
//		if(cacheTable == null) ReImportAll();
		if(cacheTable == null) return;

		if(cacheTable.GetTable().Keys.Contains(keyGUID)){
			if(ContainReference(keyGUID, refData)) {
				int index = cacheTable.GetTable()[keyGUID].FindIndex(d => 
					(d.refGUID == refData.refGUID && d.instanceID == refData.instanceID && d.propertyCount == refData.propertyCount));
				cacheTable.GetTable()[keyGUID].RemoveAt(index);
			}
		}
	}

	public static void ClearReference (string keyGUID) {
//		if(cacheTable == null) ReImportAll();
		if(cacheTable == null) return;

		if(cacheTable.GetTable().Keys.Contains(keyGUID)){
			cacheTable.GetTable().Remove(keyGUID);
		}
	}

	public static void ClearAll () {
		cacheTable.Reset();
	}

	public static bool ContainReference (string keyGUID, ARMCacheData data) {
		if(cacheTable == null) ReImportAll();

		if(cacheTable.GetTable().Keys.Contains(keyGUID)){
			//dataがすべて一致するのがあればtrue
			if(cacheTable.GetTable()[keyGUID].Any(d => 
				(d.refGUID == data.refGUID && d.instanceID == data.instanceID && d.propertyCount == data.propertyCount)
			)) {
				return true;
			}else {
				return false;
			}
		}
		// Debug.Log("key Not Found");
		return false;
	}
}