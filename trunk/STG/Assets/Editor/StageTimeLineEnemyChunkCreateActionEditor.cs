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

}
