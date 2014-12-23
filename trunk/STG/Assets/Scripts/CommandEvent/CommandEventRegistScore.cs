/*===========================================================================*/
/*
*     * FileName    : CommandEventRegistScore.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

public class CommandEventRegistScore : MonoBehaviour
{
	void OnCommandEvent()
	{
		ReferenceManager.Instance.refScoreManager.RegistGameStatus();
	}
}
