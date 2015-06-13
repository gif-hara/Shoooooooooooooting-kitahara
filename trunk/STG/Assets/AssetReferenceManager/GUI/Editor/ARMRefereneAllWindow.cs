using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class ARMRefereneAllWindow : EditorWindow {

	static private ARMRefereneAllWindow window;
	static Dictionary<string, AssetData> assetTable = new Dictionary<string, AssetData>();
	static Dictionary<string, List<AssetData>> refDataTable = new Dictionary<string, List<AssetData>>();
	static Dictionary<string, bool> foldOutTable = new Dictionary<string, bool>();

	[MenuItem("Window/AssetReferenceManager/ViewAllReference")]
	static void Init () {
		assetTable = new Dictionary<string, AssetData> ();
		refDataTable = new Dictionary<string, List<AssetData>> ();
		foldOutTable = new Dictionary<string, bool> ();
		window = GetWindow<ARMRefereneAllWindow>();
		foreach(string path in AssetDatabase.GetAllAssetPaths()){
			List<AssetData> dataList = ARMAPI.GetReferencedObjectListAtPath(path);

			if(!assetTable.Keys.Contains(path)) {
				assetTable.Add(path, new AssetData(path));
				refDataTable.Add(path, dataList);
				foldOutTable.Add(path, false);
			}
		}
	}

	Vector2 scrollPos;

	void OnGUI () {
		if(window == null) GetWindow<ARMRefereneAllWindow>().Close();

		if (assetTable.Count == 0) {
			EditorGUILayout.TextField("参照されているアセットはありません", GUILayout.Width(400));
			return;
		}

		scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
		foreach(string path in assetTable.Keys){

			int count = refDataTable[path].Count;
			if(count == 0)continue;

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.ObjectField(assetTable[path].obj, assetTable[path].type, false, GUILayout.Width(200));
			EditorGUILayout.TextField(path, GUILayout.Width(400));
			EditorGUILayout.EndHorizontal();

			foldOutTable[path] = EditorGUILayout.Foldout(foldOutTable[path], "上を参照しているアセットが " + count + "個あります");
			if(foldOutTable[path]){

				EditorGUILayout.BeginHorizontal();
				EditorGUI.indentLevel ++;
				EditorGUILayout.LabelField("参照しているオブジェクト", GUILayout.Width(200));
				EditorGUI.indentLevel --;
				EditorGUILayout.LabelField("型名", GUILayout.Width(200));
				EditorGUILayout.LabelField("プロパティ名", GUILayout.Width(150));
				EditorGUILayout.LabelField("パス", GUILayout.Width(400));
				EditorGUILayout.EndHorizontal();

				foreach(AssetData refData in refDataTable[path]) {
					EditorGUILayout.BeginHorizontal();
					EditorGUI.indentLevel ++;
					EditorGUILayout.ObjectField(refData.obj, refData.type, false, GUILayout.Width(200));
					EditorGUI.indentLevel --;
					EditorGUILayout.TextField(refData.type.Name, GUILayout.Width(200));
					EditorGUILayout.TextField(refData.property.name, GUILayout.Width(150));
					EditorGUILayout.TextField(refData.path, GUILayout.Width(400));
					EditorGUILayout.EndHorizontal();

				}
			}
			GUILayout.Space(10f);
		}
		EditorGUILayout.EndScrollView();
	}

}
