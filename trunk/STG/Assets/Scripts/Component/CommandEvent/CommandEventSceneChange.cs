/*===========================================================================*/
/*
*     * FileName    : CommandEventSceneChange.cs
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
public class CommandEventSceneChange : MonoBehaviour
{
	[SerializeField]
	private SceneManager.EffectType startEffectType;

	[SerializeField]
	private SceneManager.EffectType endEffectType;

	[SerializeField]
	private string sceneName;

	[SerializeField]
	private GameObject refConditionObject;

	void OnCommandEvent( CommandManager.CommandEventData data )
	{
		var holder = new ConditionHolder();
		holder.IsSuccess = true;
		if( refConditionObject != null )
		{
			refConditionObject.SendMessage( ConditionHolder.ConditionMessage, holder );
		}

		if( holder.IsSuccess )
		{
			data.LockInput();
			SceneManager.Instance.Change( startEffectType, endEffectType, sceneName );
		}
	}
}
