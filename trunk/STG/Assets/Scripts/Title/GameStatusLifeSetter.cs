/*===========================================================================*/
/*
*     * FileName    : GameStatusLifeSetter.cs
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
public class GameStatusLifeSetter : MonoBehaviour
{
	void Start ()
	{
		GameStatusInterfacer.Life = SaveData.Settings.Instance.Life;
	}
}
