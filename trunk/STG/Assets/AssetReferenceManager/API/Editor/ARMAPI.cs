using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ARMAPI {

	static public List<AssetData> GetReferencedObjectListAtPath (string path) {
		return GetReferencedObjectListAtGUID (AssetDatabase.AssetPathToGUID(path));
	}
	static public List<AssetData> GetReferencedObjectListAtGUID (string guid) {

		List<ARMCacheData> refDataList = ARMReferenceCache.GetReferenceList(guid);
		List<AssetData> dic = new List<AssetData>();
		if(refDataList == null) return dic;

		foreach(ARMCacheData refData in refDataList){
			string refGUID = refData.refGUID;
			string refPath = AssetDatabase.GUIDToAssetPath(refData.refGUID);
			Object refObj = null;
			System.Type refType = null;
			SerializedProperty refProperty = null;

			foreach(Object obj in AssetDatabase.LoadAllAssetsAtPath(refPath)){
				if(obj == null) continue;
				if( obj.GetInstanceID() == refData.instanceID) {
					refObj = obj;
					refType = refObj.GetType();
					SerializedObject sobj = new SerializedObject(refObj);
					if(sobj == null) {sobj.Dispose(); continue;}
					SerializedProperty sprop = sobj.GetIterator();
					if(sprop == null) {sobj.Dispose(); continue;}
					int count = 0;
					while(sprop.Next(true)){
						count ++;
						if(count == refData.propertyCount) {
							refProperty = sprop;
							continue;
						}
					}
				}
			}
			if(refObj != null)
				dic.Add(new AssetData(refGUID, refPath, refObj, refType, refProperty));
		}
		return dic;
	}

}

public class AssetData {

	public string guid;
	public string path;
	public Object obj;
	public System.Type type;
	public SerializedProperty property;

	public AssetData (string path) {
		this.path = path;
		this.guid = AssetDatabase.AssetPathToGUID(path);
		this.obj = AssetDatabase.LoadMainAssetAtPath(path);
		this.type = this.obj.GetType();
	}
	public AssetData (string guid, string path, Object obj, System.Type type, SerializedProperty property) {
		this.guid = guid;
		this.path = path;
		this.obj = obj;
		this.type = type;
		this.property = property;
	}
}
