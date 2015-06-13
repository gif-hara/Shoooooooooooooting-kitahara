using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ARMSettings : ScriptableObject {
	#if UNITY_EDITOR
	[MenuItem("Window/AssetReferenceManager/Settings")]
	#endif
	static void Init () {
		#if UNITY_EDITOR
		foreach(string path in AssetDatabase.GetAllAssetPaths()){
			if(path.IndexOf("AssetReferenceManager/Settings/Settings") != -1){
				Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(path);
				return;
			}
		}
		#endif
	}

	static private ARMSettings instance = null;
	static public ARMSettings Instance {
		get {
			if(instance == null) {
				#if UNITY_EDITOR

				foreach(string path in AssetDatabase.GetAllAssetPaths()) {
					if(path.IndexOf("AssetReferenceManager/Settings/Settings") != -1) {
						instance = (ARMSettings)AssetDatabase.LoadMainAssetAtPath(path);
					}
				}
				if(instance == null) {
					Debug.LogError("Settingファイルが見つかりませんでした");
				}
				#endif
			}
			return instance;
		}
	}

	//	[PrefixLabel("参照関係を監視する")]
	//	[Tooltip("アセットの変更時に参照関係を調べて保存します\nSaveProject時に負荷が少し大きくなる代わりに\n検索が高速になります")]
	//	public bool monitorReference;

	[PrefixLabel("ファイルの拡張子")]
	public List<string> targetExtensionList;
}
