//by Bob Berkebile : Pixelplacement : http://www.pixelplacement.com

using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(iTweenPath))]
public class iTweenPathEditor : A_EditorMonoBehaviour<iTweenPath>
{
	GUIStyle style = new GUIStyle();
	public static int count = 0;
	
	void OnEnable(){
		//i like bold handle labels since I'm getting old:
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.white;

		//lock in a default path name:
		if(!Target.initialized){
			Target.initialized = true;
			Target.pathName = "New Path " + ++count;
			Target.initialName = Target.pathName;
		}
	}
	
	public override void OnInspectorGUI(){		
		//path name:
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Path Name");
		Target.pathName = EditorGUILayout.TextField(Target.pathName);
		EditorGUILayout.EndHorizontal();
		
		if(Target.pathName == ""){
			Target.pathName = Target.initialName;
		}
		
		//path color:
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Path Color");
		Target.pathColor = EditorGUILayout.ColorField(Target.pathColor);
		EditorGUILayout.EndHorizontal();
		
		//exploration segment count control:
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel("Node Count");
		Target.nodeCount =  Mathf.Clamp(EditorGUILayout.IntSlider(Target.nodeCount, 0, 10), 2,100);
		EditorGUILayout.EndHorizontal();
		
		//add node?
		if(Target.nodeCount > Target.nodes.Count){
			for (int i = 0; i < Target.nodeCount - Target.nodes.Count; i++) {
				Target.nodes.Add(Vector3.zero);	
			}
		}
	
		//remove node?
		if(Target.nodeCount < Target.nodes.Count){
			if(EditorUtility.DisplayDialog("Remove path node?","Shortening the node list will permantently destory parts of your path. This operation cannot be undone.", "OK", "Cancel")){
				int removeCount = Target.nodes.Count - Target.nodeCount;
				Target.nodes.RemoveRange(Target.nodes.Count-removeCount,removeCount);
			}else{
				Target.nodeCount = Target.nodes.Count;	
			}
		}
				
		//node display:
		for (int i = 0; i < Target.nodes.Count; i++) {
			Target.nodes[i] = EditorGUILayout.Vector3Field("Node " + (i+1), Target.nodes[i]);
			EditorGUILayout.BeginHorizontal();
			Button( "Add", () =>
			{
				Target.nodes.Insert( i, Target.nodes[i] );
				Target.nodeCount = Target.nodes.Count;
			});
			Button( "Delete", () =>
			{
				Target.nodes.Remove( Target.nodes[i] );
				Target.nodeCount = Target.nodes.Count;
			});
			EditorGUILayout.EndHorizontal();
		}

		Line();
		Button( "Sync Last Node", () =>
		{
			var initPos = Target.nodes[0];
			Target.nodes[Target.nodes.Count-1] = initPos;
		});
		
		//update and redraw:
		if(GUI.changed){
			EditorUtility.SetDirty(Target);			
		}
	}
	
	void OnSceneGUI(){
		if(Target.enabled) { // dkoontz
			if(Target.nodes.Count > 0){
				//allow path adjustment undo:
				Undo.SetSnapshotTarget(Target,"Adjust iTween Path");
				
				//path begin and end labels:
				Handles.Label(Target.nodes[0], "'" + Target.pathName + "' Begin", style);
				Handles.Label(Target.nodes[Target.nodes.Count-1], "'" + Target.pathName + "' End", style);
				
				//node handle display:
				for (int i = 0; i < Target.nodes.Count; i++) {
					Target.nodes[i] = Handles.PositionHandle(Target.nodes[i], Quaternion.identity);
				}	
			}
		} // dkoontz
	}
}