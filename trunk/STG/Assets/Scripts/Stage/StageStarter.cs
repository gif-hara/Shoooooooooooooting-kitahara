/*===========================================================================*/
/*
*     * FileName    : StageStarter.cs
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
public class StageStarter : GameMonoBehaviour
{
	[SerializeField]
	private List<StageManager> prefabStageList;

	public override void Awake()
	{
		InstantiateAsChild( gameObject, prefabStageList[GameStatusInterfacer.StageId].gameObject );
	}
}
