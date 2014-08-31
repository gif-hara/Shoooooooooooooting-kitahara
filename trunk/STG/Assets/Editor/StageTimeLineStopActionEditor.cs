/*===========================================================================*/
/*
*     * FileName    : StageTimeLineStopActionEditor.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor( typeof( StageTimeLineStopAction ) )]
public class StageTimeLineStopActionEditor : A_StageTimeLineActionEditor<StageTimeLineStopAction>
{
	public override void OnInspectorGUI()
	{
		Enclose( "Property", () =>
		{
			DrawTimeLine();
			Target.delayDuration = IntField( "Delay", Target.delayDuration );
			Target.exceptionDuration = IntField( "Exception Duration", Target.exceptionDuration );
			Target.needDestroyEnemyId = IntField( "Need Enemy Id", Target.needDestroyEnemyId );
			Target.needDestroyEnemyNum = IntField( "Need Enemy Destroy", Target.needDestroyEnemyNum );
		});
	}
}
