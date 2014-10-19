/*===========================================================================*/
/*
*     * FileName    : GameStatusInterfacer.cs
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
public static class GameStatusInterfacer
{
	/// <summary>
	/// 難易度.
	/// </summary>
	/// <value>The difficulty.</value>
	public static GameDefine.DifficultyType Difficulty{ set; get; }

	/// <summary>
	/// 始めるステージID.
	/// </summary>
	/// <value>The stage identifier.</value>
	public static int StageId{ set; get; }

	/// <summary>
	/// タイトル画面で決めたステージID.
	/// </summary>
	/// <value>The title decide stage identifier.</value>
	public static int TitleDecideStageId{ set; get; }

	/// <summary>
	/// プレイヤーID.
	/// </summary>
	/// <value>The player identifier.</value>
	public static int PlayerId{ set; get; }

	/// <summary>
	/// リプレイID.
	/// </summary>
	/// <value>The replay identifier.</value>
	public static int ReplayId{ set; get; }

	/// <summary>
	/// ゲームモード.
	/// </summary>
	/// <value>The game mode.</value>
	public static GameDefine.GameModeType GameMode{ set{ gameMode = value; } get{ return gameMode; } }
	private static GameDefine.GameModeType gameMode = GameDefine.GameModeType.PlayerInput;
}
