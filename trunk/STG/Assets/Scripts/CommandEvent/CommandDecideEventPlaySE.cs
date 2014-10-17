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
public class CommandDecideEventPlaySE : MonoBehaviour
{
	[SerializeField]
	private string label;

	void OnCommandEvent()
	{
		SoundManager.Instance.Play( label );
	}
}
