/*===========================================================================*/
/*
*     * FileName    : StageTimeLineSceneChangePracticeMode.cs
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
public class StageTimeLineSceneChangePracticeMode : A_StageTimeLineActionable
{
	public override void Action ()
	{
		if( GameStatusInterfacer.PlayStyle != GameDefine.PlayStyleType.Practice )	return;

		var sceneName = GameStatusInterfacer.GameMode == GameDefine.GameModeType.PlayerInput
			? "SaveReplay"
			: "LoadReplay";

		SceneManager.Instance.Change( SceneManager.EffectType.Fast, SceneManager.EffectType.Default, sceneName );
	}
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] SceneChangePracticeMode", timeLine );
		}
	}
}
