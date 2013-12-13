//================================================
/*!
    @file   StageCreatorWindow.cs

    @brief  .

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class StageCreatorWindow : A_EditorWindowBase
{
	private static StageCreatorWindow instance;

	private StageManager Manager
	{
		get
		{
			return manager ?? (manager = GameObject.FindWithTag( "Stage" ).GetComponent<StageManager>());
		}
	}
	private StageManager manager;

	[MenuItem( "Window/StageCreator" )]
	private static void CreateWindow()
	{
		instance = EditorWindow.GetWindow<StageCreatorWindow>();
	}

	void OnGUI()
	{
		EditorGUILayout.LabelField( Manager.gameObject.name );
		Button( "Select", () => Selection.activeGameObject = Manager.gameObject );
	}
}
