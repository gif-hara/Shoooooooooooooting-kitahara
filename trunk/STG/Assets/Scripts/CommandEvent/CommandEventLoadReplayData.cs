/*===========================================================================*/
/*
*     * FileName    : CommandEventLoadReplayData.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

public class CommandEventLoadReplayData : MonoBehaviour
{
	private int id;

	void OnCommandEvent()
	{
		var data = SaveLoad.LoadReplayData (id);
		GameStatusInterfacer.Difficulty = data.Difficulty;
		GameStatusInterfacer.PlayStyle = data.PlayStyle;
		GameStatusInterfacer.PlayerId = data.PlayerId;
		GameStatusInterfacer.ReplayId = id;
		GameStatusInterfacer.StageId = data.StageId;
		GameStatusInterfacer.GameMode = GameDefine.GameModeType.Replay;
	}

	void OnCreatedReplayListElement( int id )
	{
		this.id = id;
	}
}
