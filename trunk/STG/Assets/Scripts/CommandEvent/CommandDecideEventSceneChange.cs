/*===========================================================================*/
/*
*     * FileName    : CommandDecideEventSceneChange.cs
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
public class CommandDecideEventSceneChange : MonoBehaviour
{
	[SerializeField]
	private SceneManager.EffectType startEffectType;

	[SerializeField]
	private SceneManager.EffectType endEffectType;

	[SerializeField]
	private string sceneName;

	void OnCommandEvent( CommandManager.CommandEventData data )
	{
		data.LockInput();
		SceneManager.Instance.Change( startEffectType, endEffectType, sceneName );
	}
}
