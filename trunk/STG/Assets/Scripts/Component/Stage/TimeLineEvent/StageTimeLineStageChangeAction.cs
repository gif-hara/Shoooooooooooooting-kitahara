/*===========================================================================*/
/*
*     * FileName    : StageTimeLineStageChangeAction.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageTimeLineStageChangeAction : A_StageTimeLineActionable
{
	/// <summary>
	/// 通常の次のステージ.
	/// </summary>
	public GameObject prefabNextStage;
	
	/// <summary>
	/// 条件を満たした場合のステージ.
	/// </summary>
	public GameObject prefabExtensionStage;
	
	public A_StageChangeConditioner refConditioner;
	
	public override void Action()
	{
		Destroy( ReferenceManager.refStageManager.gameObject );
		Instantiate( StagePrefab );
		Destroy( gameObject );
	}
	
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] StageChange", timeLine );
		}
	}
	
	private GameObject StagePrefab
	{
		get
		{
			return refConditioner.Condition() ? prefabExtensionStage : prefabNextStage;
		}
	}
}
