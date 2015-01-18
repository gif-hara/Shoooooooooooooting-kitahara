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
public class CommandEventSceneChange : ChangeScene
{
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
			Change();
		}
	}
}
