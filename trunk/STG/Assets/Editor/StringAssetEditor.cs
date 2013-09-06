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
using System.Collections.Generic;

[CustomEditor( typeof( StringAsset ) )]
public class StringAssetEditor : A_EditorScriptableObject<StringAsset>
{
	/// <summary>
	/// 検索用文字列.
	/// </summary>
	private string searchString = "";
	
	public override void OnInspectorGUI ()
	{
		DrawSystem();
		DrawElement();
	}
	/// <summary>
	/// システムの描画.
	/// </summary>
	private void DrawSystem()
	{
		Enclose( "System", () =>
		{
			// 検索フォーム.
			Horizontal( () =>
			{
				Label( "Search", Width( 50.0f ) );
				searchString = EditorGUILayout.TextField( searchString );
			});
			
			// 要素追加.
			Button( "Add", () =>
			{
				Target.Add();
				EditorUtility.SetDirty( target );
			}, Width( 60.0f ) );
		}, true, false );
		
		Line();
	}
	/// <summary>
	/// 全要素の描画.
	/// </summary>
	private void DrawElement()
	{
		for( int i=0,imax=Target.asset.Count; i<imax; i++ )
		{
			if( DrawElement( i ) )	break;
		}
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
		if( !IsHitSearch( i ) )	return false;
		
		bool isDelete = false;
		
		// Key設定.
		SetStringAndDirty( "Key", () =>  EditorGUILayout.TextField( Target.key[i] ), Target.key, i );
		
		// Asset設定.
		SetStringAndDirty( "Asset", () =>  EditorGUILayout.TextArea( Target.asset[i] ), Target.asset, i );
		
		Horizontal( () =>
		{
			// 要素を一つ上へスワップ.
			Button( "Up", () =>
			{
				Target.Swap( i, i-1 );
				EditorUtility.SetDirty( target );
			},  Width( 50.0f ) );
			
			// 要素を一つ下へスワップ.
			Button( "Down", () =>
			{
				Target.Swap( i, i+1 );
				EditorUtility.SetDirty( target );
			},  Width( 50.0f ) );
			
			Space();
			
			// 要素の削除.
			Button( "Delete", () =>
			{
				Target.Delete( i );
				EditorUtility.SetDirty( target );
				isDelete = true;
			}, Width( 60.0f ) );
		});
		
		Line();
		
		return isDelete;
	}
	/// <summary>
	/// 文字列設定とEditor通知処理.
	/// </summary>
	/// <param name='encloseLabel'>
	/// Enclose label.
	/// </param>
	/// <param name='inputFunc'>
	/// Input func.
	/// </param>
	/// <param name='list'>
	/// List.
	/// </param>
	/// <param name='i'>
	/// I.
	/// </param>
	private void SetStringAndDirty( string encloseLabel, System.Func<string> inputFunc, List<string> list, int i )
	{
		Enclose( encloseLabel, () =>
		{
			var input = inputFunc();
			if( list[i].CompareTo( input ) != 0 )
			{
				list[i] = input;
				EditorUtility.SetDirty( target );
			}
		}, false, false );
	}
	/// <summary>
	/// 検索にヒットする要素であるか？.
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance is hit search the specified id; otherwise, <c>false</c>.
	/// </returns>
	/// <param name='id'>
	/// If set to <c>true</c> identifier.
	/// </param>
	private bool IsHitSearch( int id )
	{
		// 検索していなければ常にヒット.
		if( string.IsNullOrEmpty( searchString ) )
		{
			return true;
		}
		
		// すべて小文字にしてヒットしやすくする.
		var lowSearchString = searchString.ToLower();
		return Target.key[id].ToLower().IndexOf( lowSearchString ) != -1 || Target.asset[id].ToLower().IndexOf( lowSearchString ) != -1;
	}
}
