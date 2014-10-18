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
	public static GameDefine.DifficultyType Difficulty{ set; get; }

	public static int StageId{ set; get; }

	public static int PlayerId{ set; get; }

	public static int ReplayId{ set; get; }

	public static GameDefine.GameModeType GameMode{ set{ gameMode = value; } get{ return gameMode; } }
	private static GameDefine.GameModeType gameMode = GameDefine.GameModeType.Replay;

	public static int RandomSeed{ set; get; }
}
