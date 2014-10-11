/*===========================================================================*/
/*
*     * FileName    : StageTimeLinePlayBGM.cs
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
public class StageTimeLinePlayBGM : A_StageTimeLineActionable
{
	public string label;

	public override void Action ()
	{
		ReferenceManager.Instance.refSoundManager.PlayBGM( label );
	}
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] PlayBGM", timeLine );
		}
	}
}
