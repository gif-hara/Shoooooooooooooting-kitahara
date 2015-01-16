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
	public static GameDefine.InputType GameMode{ set{ gameMode = value; } get{ return gameMode; } }
	private static GameDefine.InputType gameMode = GameDefine.InputType.User;

	/// <summary>
	/// プレイスタイル.
	/// </summary>
	/// <value>The play style.</value>
	public static GameDefine.PlayStyleType PlayStyle{ set{ playStyle = value; } get{ return playStyle; } }
	private static GameDefine.PlayStyleType playStyle = GameDefine.PlayStyleType.NewGame;

	/// <summary>
	/// リトライ時に復帰するスコア.
	/// ゲームオーバー時に評価されるスコア.
	/// </summary>
	/// <value>The score.</value>
	public static ulong Score{ set; get; }

	/// <summary>
	/// リトライ時に復帰するハイスコア.
	/// </summary>
	/// <value>The high score.</value>
	public static ulong HighScore{ set; get; }

	/// <summary>
	/// リトライ時に復帰するゲームレベル.
	/// </summary>
	/// <value>The game level.</value>
	public static int GameLevel{ set; get; }

	/// <summary>
	/// リトライ時に復帰するゲームレベル経験値.
	/// </summary>
	/// <value>The game level experience.</value>
	public static float GameLevelExperience{ set; get; }

	/// <summary>
	/// リトライ時に復帰するグレイズ回数.
	/// </summary>
	/// <value>The graze count.</value>
	public static int GrazeCount{ set; get; }

	/// <summary>
	/// リトライ時に復帰する裏ステージ突入フラグ.
	/// </summary>
	/// <value>The reverse stage flag list.</value>
	public static List<bool> ReverseStageFlagList{ set; get; }

	/// <summary>
	/// リトライ時に復帰する自機数.
	/// </summary>
	/// <value>The life.</value>
	public static int Life{ set{ life = value; } get{ return life; } }
	private static int life = 3;

	/// <summary>
	/// リトライ時に復帰するSP.
	/// </summary>
	/// <value>The special point.</value>
	public static float SpecialPoint{ set; get; }

	/// <summary>
	/// リトライ時に復帰するエクステンド回数.
	/// </summary>
	/// <value>The extend count.</value>
	public static int ExtendCount{ set; get; }

	/// <summary>
	/// リトライ時に復帰するミス回数.
	/// </summary>
	/// <value>The miss count.</value>
	public static int MissCount{ set; get; }

	public static void ResetRetryData()
	{
		Score = 0;
		HighScore = 0;
		GameLevel = 0;
		GameLevelExperience = 0;
		GrazeCount = 0;
		ReverseStageFlagList = new List<bool>();
		Life = 3;
		SpecialPoint = 0;
		ExtendCount = 0;
		MissCount = 0;
	}
}
