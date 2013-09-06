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

//[CustomEditor( typeof( StringAsset ) )]
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
	
	private bool DrawElement( int i )
	{
		bool isDelete = false;
		
		Enclose( "Key", () =>
		{
			Target.key[i] = EditorGUILayout.TextArea( Target.key[i] );
		}, false, false );
		Enclose( "Asset", () =>
		{
			Target.asset[i] = EditorGUILayout.TextArea( Target.asset[i] );
		}, false, false );
		Button( "Delete", () =>
		{
			Target.Delete( i );
			isDelete = true;
		}, Width( 60.0f ) );
		Line();
		
		return isDelete;
	}
}
