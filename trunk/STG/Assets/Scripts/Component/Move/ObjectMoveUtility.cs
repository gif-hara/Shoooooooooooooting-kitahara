/*===========================================================================*/
/*
*     * FileName    : ObjectMoveUtility.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class ObjectMoveUtility
{
	public enum MoveType : int
	{
		ObjectMoveTween,
		ObjectMoveChasePlayer,
		ObjectMoveRandomRect,
		ObjectMoveITweenPath,
	}
	
	public static A_ObjectMove CreateObjectMove( Transform parent, A_ObjectMove.Data data )
	{
		var obj = new GameObject( data.ToString() );
		obj.transform.parent = parent;
		A_ObjectMove moveComponent = obj.AddComponent( data.moveType.ToString() ) as A_ObjectMove;
		moveComponent.InitData( data );
		
		return moveComponent;
	}
	/// <summary>
	/// MoveTypeの名前をリストにして返す.
	/// </summary>
	/// <value>
	/// The move type strings.
	/// </value>
	public static string[] MoveTypeStrings
	{
		get
		{
			return Enum.GetNames( typeof( MoveType ) );
		}
	}
	public static List<string> MoveTypeStringsToList
	{
		get
		{
			return new List<string>( MoveTypeStrings );
		}
	}
	/// <summary>
	/// MoveTypeをIDリストにして返す.
	/// </summary>
	/// <value>
	/// The move type identifier list.
	/// </value>
	public static int[] MoveTypeIdList
	{
		get
		{
			List<int> result = new List<int>();
			
			foreach( int i in Enum.GetValues( typeof( MoveType ) ) )
			{
				result.Add( i );
			}
			
			return result.ToArray();
		}
	}
	public static void AllDetach( GameObject go )
	{
		var components = go.GetComponentsInChildren<A_ObjectMove>();
		System.Array.ForEach<A_ObjectMove>( components, (obj) =>
		{
			if( obj.data.initFuncName != "FallOut" )
			{
				UnityEngine.Object.Destroy( obj.gameObject );
			}
		});
	}
	public static void Attach( Transform trans, A_ObjectMove objectMoveOnPrefab )
	{
		var currentObject = GameMonoBehaviour.InstantiateAsChild( trans, objectMoveOnPrefab.gameObject );
		var list = currentObject.GetComponents<A_ObjectMove>();
		System.Array.ForEach<A_ObjectMove>( list, a =>
		{
			a.refTrans = trans;
		});
	}
}
