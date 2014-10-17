/*===========================================================================*/
/*
*     * FileName    : CommandEventDifficultySetter.cs
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
public class CommandEventDifficultySetter : MonoBehaviour
{
	[SerializeField]
	private GameDefine.DifficultyType type;

	void OnCommandEvent()
	{
		GameStatusInterfacer.Difficulty = type;
	}
}
