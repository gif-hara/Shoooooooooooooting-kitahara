/*===========================================================================*/
/*
*     * FileName    : StageTimeLineStartStage.cs
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
public class StageTimeLineStartStage : A_StageTimeLineActionable
{
	public override void Action ()
	{
		ReferenceManager.Instance.refUILayer.BroadcastMessage( GameDefine.StartStageMessage );
	}
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] StartStage", timeLine );
		}
	}

}
