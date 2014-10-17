/*===========================================================================*/
/*
*     * FileName    : CommandDecideEventPlaySE.cs
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
public class CommandDecideEventPlaySECondition : MonoBehaviour
{
	[SerializeField]
	private string successLabel;
	
	[SerializeField]
	private string failureLabel;

	[SerializeField]
	private GameObject refConditionObject;
		
	void OnCommandEvent()
	{
		var holder = new ConditionHolder();
		refConditionObject.SendMessage( ConditionHolder.ConditionMessage, holder );
		string label = holder.IsSuccess ? successLabel : failureLabel;
		SoundManager.Instance.Play( label );
	}
}
