/*===========================================================================*/
/*
*     * FileName    : StringAssetEditor.cs
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

[CustomEditor( typeof( StringAsset ) )]
public class StringAssetEditor : A_EditorScriptableObject<StringAsset>
{
	public override void OnInspectorGUI ()
	{
		DrawSystem();
		
		for( int i=0,imax=Target.asset.Count; i<imax; i++ )
		{
			if( DrawElement( i ) )	break;
		}
	}
	/// <summary>
	/// システムの描画.
	/// </summary>
	private void DrawSystem()
	{
		Enclose( "System", () =>
		{
			Button( "Add", () =>
			{
				Target.Add();
			}, Width( 60.0f ) );
		}, true, false );
		
		Line();
	}
	/// <summary>
	/// 要素の描画.
	/// </summary>
	/// <returns>
	/// The element.
	/// </returns>
	/// <param name='i'>
	/// If set to <c>true</c> i.
	/// </param>
	private bool DrawElement( int i )
	{
		bool isDelete = false;
		
		SetStringAndDirty( "Key", Target.key, i );
		SetStringAndDirty( "Asset", Target.asset, i );
		Button( "Delete", () =>
		{
			Target.Delete( i );
			isDelete = true;
		}, Width( 60.0f ) );
		Line();
		
		return isDelete;
	}
	/// <summary>
	/// 文字列設定とEditor通知処理.
	/// </summary>
	/// <param name='list'>
	/// List.
	/// </param>
	/// <param name='i'>
	/// I.
	/// </param>
	private void SetStringAndDirty( string encloseLabel, List<string> list, int i )
	{
		Enclose( encloseLabel, () =>
		{
			var input = EditorGUILayout.TextArea( list[i] );
			if( list[i].CompareTo( input ) != 0 )
			{
				list[i] = input;
				EditorUtility.SetDirty( target );
			}
		}, false, false );
	}
}
