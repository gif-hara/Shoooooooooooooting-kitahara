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
	/// <summary>
	/// 通常ゲームモードのステージプレハブ.
	/// </summary>
	[SerializeField]
	private List<StageManager> prefabStageList;

	/// <summary>
	/// ボスラッシュモードのステージプレハブ.
	/// </summary>
	[SerializeField]
	private List<StageManager> prefabBossRushStageList;

	public override void Awake()
	{
		if( GameStatusInterfacer.StageId == -1 )
		{
			Debug.LogWarning( "It was not possible to produce a stage. StageId = " + GameStatusInterfacer.StageId );
			return;
		}

		if(
			GameStatusInterfacer.PlayStyle == GameDefine.PlayStyleType.NewGame ||
			GameStatusInterfacer.PlayStyle == GameDefine.PlayStyleType.Practice
		   )
		{
			InstantiateAsChild( gameObject, prefabStageList[GameStatusInterfacer.StageId].gameObject );
		}
		else
		{
			InstantiateAsChild( gameObject, prefabBossRushStageList[GameStatusInterfacer.StageId].gameObject );
		}
	}
}
