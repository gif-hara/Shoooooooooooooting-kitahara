/*===========================================================================*/
/*
*     * FileName    : StageTimeLineFadeBGM.cs
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
public class StageTimeLineFadeBGM : A_StageTimeLineActionable
{
	public float from;

	public float to;

	public int duration;

	public override void Action ()
	{
		ReferenceManager.Instance.refSoundManager.FadeBGM( from, to, duration );
	}
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] FadeBGM", timeLine );
		}
	}
}
