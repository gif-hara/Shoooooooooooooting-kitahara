/*===========================================================================*/
/*
*     * FileName    : StageTimeLineStartResult.cs
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
public class StageTimeLineStartResult : A_StageTimeLineActionable
{
	[SerializeField]
	private int stageId;

	public override void Action ()
	{
		ReferenceManager.refUILayer.BroadcastMessage( GameDefine.StartResultMessage );
		ReferenceManager.refPlayerLayer.BroadcastMessage( GameDefine.StartResultMessage );

		SaveData.Progresses.Instance.StageClear( GameStatusInterfacer.Difficulty, stageId );
		SaveLoad.SaveProgresses ();

		Destroy( gameObject );
	}

	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] StartResult", timeLine );
		}
	}
}
