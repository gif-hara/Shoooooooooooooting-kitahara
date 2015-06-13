using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class ARMRefereneWindow : EditorWindow {

	static private ARMRefereneWindow window;

	static private Object SelectedObject;
	static private string SelectedPath;
	static private string SelectedGUID;

	static List<AssetData> refDataTable;

	[MenuItem("Assets/ViewReference")]
	static void Init () {
		window = GetWindow<ARMRefereneWindow>();
		window.minSize = new Vector2(800, 200);
		SelectedObject = Selection.activeObject;
		SelectedPath = AssetDatabase.GetAssetPath(SelectedObject);
		if(string.IsNullOrEmpty(SelectedPath)){
			SelectedObject = null;
			SelectedPath = "";
			SelectedGUID = "";
		}else {
			SelectedGUID = AssetDatabase.AssetPathToGUID(SelectedPath);
		}
		refDataTable = ARMAPI.GetReferencedObjectListAtGUID(SelectedGUID);
	}

	static void Destroy () {
		System.GC.Collect();
		GetWindow<ARMRefereneWindow>().Close();
	}

	Vector2 scrollPos;

	void OnGUI () {
		if(window == null) Destroy();

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.ObjectField(SelectedObject, typeof(Object), false, GUILayout.Width(200));
		EditorGUILayout.TextField(SelectedPath, GUILayout.Width(300));
		EditorGUILayout.TextField(SelectedGUID, GUILayout.Width(300));
		EditorGUILayout.EndHorizontal();

		if(refDataTable == null) {
			EditorGUILayout.LabelField("どのオブジェクトからも参照されていません");
			return;
		}
		
		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();
		EditorGUI.indentLevel ++;
		EditorGUILayout.LabelField("参照オブジェクト", GUILayout.Width(200));
		EditorGUI.indentLevel --;
		EditorGUILayout.LabelField("型名", GUILayout.Width(200));
		EditorGUILayout.LabelField("プロパティ名", GUILayout.Width(200));
		EditorGUILayout.LabelField("パス");
		EditorGUILayout.EndHorizontal();

		scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
		foreach(AssetData refData in refDataTable) {
			EditorGUILayout.BeginHorizontal();
			EditorGUI.indentLevel ++;
			EditorGUILayout.ObjectField(refData.obj, refData.type, true, GUILayout.Width(200));
			EditorGUI.indentLevel --;
			EditorGUILayout.TextField(refData.type.ToString(), GUILayout.Width(200));
			EditorGUILayout.TextField((refData.property==null)?"":refData.property.name, GUILayout.Width(200));
			EditorGUILayout.TextField(refData.path);
			EditorGUILayout.EndHorizontal();
		}
		EditorGUILayout.EndScrollView();
	}

}
