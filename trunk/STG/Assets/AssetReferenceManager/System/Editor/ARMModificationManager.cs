using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ARMModificationManager {


	static public void Modify (string path) {
		if(ARMReferenceCache.IsLoaded == false) return;
		if(ARMReferenceCache.IsIgnore(path)) return;

		string guid = AssetDatabase.AssetPathToGUID(path);

		//自分を参照しているAssetsの参照リストから自分を消す 
		foreach(string refPath in AssetDatabase.GetAllAssetPaths()){
			ARMReferenceCache.RemoveReference(AssetDatabase.AssetPathToGUID(refPath), guid);
		}

		//参照一覧取得
		ARMReferenceCache.AnalyzeProperty(path);
	}

	static public void Delete (string path) {
		if(ARMReferenceCache.IsLoaded == false) return;

		string guid = AssetDatabase.AssetPathToGUID(path);

		List<ARMCacheData> redDataList = ARMReferenceCache.GetReferenceList(guid);
		if(redDataList != null){
			//このGUIDを参照するキャッシュを削除 
			foreach(ARMCacheData refData in redDataList){
				ARMReferenceCache.RemoveReference(refData.refGUID, guid);
			}
		}

		ARMReferenceCache.ClearReference(guid);
	}
}
