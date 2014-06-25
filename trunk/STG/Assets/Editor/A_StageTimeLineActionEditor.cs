/*===========================================================================*/
/*
*     * FileName    : A_StageTimeLineActionEditor.cs
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


public class A_StageTimeLineActionEditor<T> : A_EditorMonoBehaviour<T> where T : A_StageTimeLineActionable
{
	/// <summary>
	/// 複数選択時のタイムライン設定値.
	/// </summary>
	private int multiSettingTimeLine = 0;

	/// <summary>
	/// タイムライン設定.
	/// </summary>
	protected void DrawTimeLine()
	{
		Horizontal( () =>
		{
			int timeLine = IntField( "Time Line", Target.timeLine );
			timeLine = timeLine < 0 ? 0 : timeLine;
			if( timeLine != Target.timeLine )
			{
				Target.timeLine = timeLine;
				Target.SyncData();
			}
			
		});
	}

	protected void DrawActionConditioner()
	{
		Horizontal( () =>
		{
			Target.refActionConditioner =
				EditorGUILayout.ObjectField( "Action Conditioner", Target.refActionConditioner, typeof( A_StageTimeLineActionConditioner ), true ) as A_StageTimeLineActionConditioner;
		});
	}
	/// <summary>
	/// 複数選択時のターゲットオブジェクト描画.
	/// </summary>
	protected void DrawTargetsMultiSetting()
	{
		Enclose( "Targets", () =>
		{
			Vertical( () =>
			{
				foreach( var t in targets )
				{
					Label( t.name );
				}
			});
		}, true );
	}
	/// <summary>
	/// 複数選択時のタイムライン設定処理.
	/// </summary>
	protected void DrawTimeLineMultiSetting()
	{
		Enclose( "Time Line", () =>
		{
			Horizontal( () =>
			{
				multiSettingTimeLine = IntField( multiSettingTimeLine, Width( 60.0f ) );
				Button( "Set", () =>
				{
					SetTimeLineMultiSetting( multiSettingTimeLine );
				});
				Button( "Add", () =>
				{
					AddTimeLineMultiSetting( multiSettingTimeLine );
				});
				Button( "Sub", () =>
				{
					AddTimeLineMultiSetting( -multiSettingTimeLine );
				});
			});
		});
	}
	/// <summary>
	/// 複数選択時のタイムライン加算処理.
	/// </summary>
	/// <param name='value'>
	/// Value.
	/// </param>
	protected void AddTimeLineMultiSetting( int value )
	{
		Undo.RegisterUndo( targets, "Change Time Line Multi Setting" );
		foreach( var t in targets )
		{
			var actionable = t as A_StageTimeLineActionable;
			actionable.timeLine += value;
			actionable.timeLine = actionable.timeLine < 0 ? 0 : actionable.timeLine;
			actionable.SyncData();
		}
	}
	/// <summary>
	/// 複数選択時のタイムライン設定処理.
	/// </summary>
	/// <param name='value'>
	/// Value.
	/// </param>
	protected void SetTimeLineMultiSetting( int value )
	{
		Undo.RegisterUndo( targets, "Change Time Line Multi Setting" );
		foreach( var t in targets )
		{
			var actionable = t as A_StageTimeLineActionable;
			actionable.timeLine = value;
			actionable.timeLine = actionable.timeLine < 0 ? 0 : actionable.timeLine;
			actionable.SyncData();
		}
	}
}
