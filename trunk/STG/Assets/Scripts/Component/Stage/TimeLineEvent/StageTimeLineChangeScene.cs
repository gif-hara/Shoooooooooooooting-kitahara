/*===========================================================================*/
/*
*     * FileName    : StageTimeLineChangeScene.cs
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
public class StageTimeLineChangeScene : A_StageTimeLineActionable
{
	[SerializeField]
	private SceneManager.EffectType startEffectType;

	[SerializeField]
	private SceneManager.EffectType endEffectType;

	[SerializeField]
	private string sceneName;

	public override void Action ()
	{
		SceneManager.Instance.Change( startEffectType, endEffectType, sceneName );
	}
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] ChangeScene", timeLine );
		}
	}
}
