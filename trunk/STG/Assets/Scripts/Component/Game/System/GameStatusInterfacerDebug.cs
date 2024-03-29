﻿/*===========================================================================*/
/*
*     * FileName    : GameStatusInterfacerDebug.cs
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
public class GameStatusInterfacerDebug : MonoBehaviour
{
	[SerializeField]
	private bool apply;

	[SerializeField]
	private GameDefine.DifficultyType difficulty;

	[SerializeField]
	private int stageId;

	[SerializeField]
	private int playerId;

	[SerializeField]
	private int replayId;

	[SerializeField]
	private GameDefine.InputType gameMode;

	[SerializeField]
	private GameDefine.PlayStyleType playStyle;

	void Awake()
	{
#if STG_DEBUG
		if( !apply )	return;

		GameStatusInterfacer.Difficulty = difficulty;
		GameStatusInterfacer.StageId = stageId;
		GameStatusInterfacer.PlayerId = playerId;
		GameStatusInterfacer.ReplayId = replayId;
		GameStatusInterfacer.GameMode = gameMode;
		GameStatusInterfacer.PlayStyle = playStyle;
#else
		Destroy( gameObject );
#endif
	}
}
