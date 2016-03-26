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
using UnityEngine.Assertions;
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
		var moveComponent = AddComponent(obj, data.moveType);
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
			if( obj.data.initFuncName != "FallOut" && !obj.data.isIgnoreDetach )
			{
				UnityEngine.Object.Destroy( obj.gameObject );
			}
		});
	}
	public static A_ObjectMove[] Attach( Transform trans, A_ObjectMove objectMoveOnPrefab )
	{
		var currentObject = GameMonoBehaviour.InstantiateAsChild( trans, objectMoveOnPrefab.gameObject );
		var list = currentObject.GetComponents<A_ObjectMove>();
		System.Array.ForEach<A_ObjectMove>( list, a =>
		{
			a.refTrans = trans;
		});

		return list;
	}

	public static A_ObjectMove AddComponent(GameObject obj, MoveType moveType)
	{
		if(moveType == MoveType.ObjectMoveTween)
		{
			return obj.AddComponent<ObjectMoveTween>();
		}
		else if(moveType == MoveType.ObjectMoveChasePlayer)
		{
			return obj.AddComponent<ObjectMoveChasePlayer>();
		}
		else if(moveType == MoveType.ObjectMoveITweenPath)
		{
			return obj.AddComponent<ObjectMoveITweenPath>();
		}
		else if(moveType == MoveType.ObjectMoveRandomRect)
		{
			return obj.AddComponent<ObjectMoveRandomRect>();
		}

		Assert.IsTrue(false, "不正な値です. moveType = " + moveType.ToString());
		return null;
	}
}
