/*===========================================================================*/
/*
*     * FileName    : StageTimeLineActionReverseStageClearFlagSetter.cs
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
public class StageTimeLineActionReverseStageClearFlagSetter : A_StageTimeLineActionable
{
	[SerializeField]
	private int stageId;

	[SerializeField]
	private bool isClear;

	public override void Action()
	{
		if( isClear )
		{
			ReferenceManager.Instance.refGameManager.ReverseStageClear( stageId );
		}
		else
		{
			ReferenceManager.Instance.refGameManager.ReverseStageFailure( stageId );
		}
		Destroy( gameObject );
	}
	
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] ReverseStageClear", timeLine );
		}
	}
}
