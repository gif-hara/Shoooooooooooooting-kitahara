/*===========================================================================*/
/*
*     * FileName    : StageTimeLineStopByResult.cs
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
public class StageTimeLineStopByResult : A_StageTimeLineActionable
{
	void OnEndResult()
	{
		ReferenceManager.refStageManager.StartTimeLine();
		Destroy( gameObject );
	}

	public override void Action ()
	{
		ReferenceManager.refStageManager.StopTimeLine();
	}

	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] TimeLineStopByResult", timeLine );
		}
	}
}
