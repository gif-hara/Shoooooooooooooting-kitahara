/*===========================================================================*/
/*
*     * FileName    : StageTimeLineSetClearedStageType.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class StageTimeLineSetClearedStageType : A_StageTimeLineActionable
{
	[SerializeField]
	private GameDefine.StageType type;

	public override void Action ()
	{
		GameStatusInterfacer.ClearedStageType = type;
	}

	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] SetClearedStageType", timeLine );
		}
	}
}
