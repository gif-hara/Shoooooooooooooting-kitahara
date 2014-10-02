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

	public override void Action()
	{
		ReferenceManager.Instance.refGameManager.ReverseStageClear( stageId );
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
