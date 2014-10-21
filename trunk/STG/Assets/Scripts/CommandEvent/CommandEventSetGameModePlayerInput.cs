/*===========================================================================*/
/*
*     * FileName    : CommandEventSetGameModePlayerInput.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

public class CommandEventSetGameModePlayerInput : MonoBehaviour
{
	void OnCommandEvent()
	{
		GameStatusInterfacer.GameMode = GameDefine.GameModeType.PlayerInput;
	}
}
