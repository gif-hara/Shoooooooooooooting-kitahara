/*===========================================================================*/
/*
*     * FileName    : StageTimeLinePrefabCreateAction.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageTimeLinePrefabCreateAction : A_StageTimeLineActionable
{
	/// <summary>
	/// 生成するプレハブ.
	/// </summary>
	public GameObject prefab;
	
	public override void Action()
	{
		Instantiate( prefab );
		Destroy( gameObject );
	}
	
	protected override string GameObjectName
	{
		get
		{
			var prefabName = prefab == null ? "" : prefab.name;
			return string.Format( "[{0}] CreatePrefab [{1}]", timeLine, prefabName );
		}
	}
}
