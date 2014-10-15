/*===========================================================================*/
/*
*     * FileName    : CommandDecideEventDifficultySetter.cs
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
public class CommandDecideEventDifficultySetter : MonoBehaviour
{
	[SerializeField]
	private GameDefine.DifficultyType type;

	void OnDecideEvent()
	{
		GameStatusInterfacer.Difficulty = type;
	}
}
