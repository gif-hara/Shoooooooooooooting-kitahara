/*===========================================================================*/
/*
*     * FileName    : ObjectExtention.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public static class ObjectExtention
{
	public static GameObject InstantiateAsChild( this Object self, GameObject parent, GameObject prefab )
	{
		GameObject obj = NGUITools.AddChild( parent, prefab );
		obj.transform.localScale = prefab.transform.localScale;
		obj.layer = prefab.layer;
		
		return obj;
	}

	public static GameObject InstantiateAsChild( this Object self, Transform parent, GameObject prefab )
	{
		return self.InstantiateAsChild( parent.gameObject, prefab );
	}
}
