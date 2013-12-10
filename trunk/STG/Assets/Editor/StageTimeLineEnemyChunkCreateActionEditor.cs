/*===========================================================================*/
/*
*     * FileName    : StageTimeLineEnemyChunkCreateActionEditor.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

[CanEditMultipleObjects]
[CustomEditor( typeof( StageTimeLineEnemyChunkCreateAction ) )]
public class StageTimeLineEnemyChunkCreateActionEditor : A_StageTimeLineActionEditor<StageTimeLineEnemyChunkCreateAction>
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		Enclose( "Property", () =>
		{
			DrawTimeLine();
			DrawInterval();
			DrawExtensionName();
		});
	}
	
	/// <summary>
	/// 生成間隔設定.
	/// </summary>
	private void DrawInterval()
	{
		Horizontal( () =>
		{
			int interval = IntField( "Interval", Target.interval );
			interval = interval < 0 ? 0 : interval;
			if( interval != Target.interval )
			{
				Target.interval = interval;
				Target.SyncData();
			}
		});
	}

	/// <summary>
	/// 名前の拡張設定.
	/// </summary>
	private void DrawExtensionName()
	{
		Horizontal( () =>
		{
			string extensionName = EditorGUILayout.TextField( "Extension Name", Target.extensionName );
			if( string.Compare( extensionName, Target.extensionName ) != 0 )
			{
				Target.extensionName = extensionName;
				Target.SyncData();
			}
		});
	}

}
