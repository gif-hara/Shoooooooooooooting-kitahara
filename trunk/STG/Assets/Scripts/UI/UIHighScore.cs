/*===========================================================================*/
/*
*     * FileName    : UIHighScore.cs
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
public class UIHighScore : UIScoreBase
{
	protected override string AssetKey
	{
		get
		{
			return "HighScoreUIFormat";
		}
	}

	protected override ulong DrawValue
	{
		get
		{
			return ReferenceManager.ScoreManager.HighScore;
		}
	}
}
