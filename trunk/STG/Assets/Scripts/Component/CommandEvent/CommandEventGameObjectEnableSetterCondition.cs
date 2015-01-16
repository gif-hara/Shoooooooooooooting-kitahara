/*===========================================================================*/
/*
*     * FileName    : CommandEventGameObjectEnableSetterCondition.cs
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
public class CommandEventGameObjectEnableSetterCondition : MonoBehaviour
{
	[SerializeField]
	private GameObject refTarget;

	[SerializeField]
	private bool isActive;

	[SerializeField]
	private GameObject refConditionObject;
	
	void OnCommandEvent()
	{
		var holder = new ConditionHolder();
		refConditionObject.SendMessage( ConditionHolder.ConditionMessage, holder );

		if( !holder.IsSuccess )
		{
			return;
		}

		refTarget.SetActive( isActive );
	}
}
