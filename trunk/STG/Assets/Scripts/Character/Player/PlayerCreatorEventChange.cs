/*===========================================================================*/
/*
*     * FileName    : PlayerCreatorEventChange.cs
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
public class PlayerCreatorEventChange : MonoBehaviour
{
	[SerializeField]
	private PlayerCreator refPlayerCreator;

	private const string PlayerInputModeMessage = "OnGameMode";

	private const string ReplayModeMessage = "OnReplayMode";

	void Awake ()
	{
		string message = GameStatusInterfacer.GameMode == GameDefine.GameModeType.PlayerInput
			? PlayerInputModeMessage
			: ReplayModeMessage;

		refPlayerCreator.ChangeCreatedMessage( message );
	}
}
