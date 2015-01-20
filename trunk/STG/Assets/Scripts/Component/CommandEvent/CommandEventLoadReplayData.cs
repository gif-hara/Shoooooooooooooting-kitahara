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
	[SerializeField]
	private BooleanConditioner refConditioner;

	private int id;

	void OnCommandEvent()
	{
		if( !refConditioner.Flag )
		{
			return;
		}
		var data = SaveLoad.LoadReplayData (id);
		GameStatusInterfacer.Difficulty = data.Difficulty;
		GameStatusInterfacer.PlayStyle = data.PlayStyle;
		GameStatusInterfacer.PlayerId = data.PlayerId;
		GameStatusInterfacer.ReplayId = id;
		GameStatusInterfacer.StageId = data.StageId;
		GameStatusInterfacer.GameMode = GameDefine.InputType.Replay;
	}

	void OnCreatedReplayListElement( int id )
	{
		this.id = id;
		refConditioner.Flag = SaveLoad.LoadReplayData (id) != null;
	}
}
