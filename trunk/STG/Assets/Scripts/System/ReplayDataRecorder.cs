/*===========================================================================*/
/*
*     * FileName    : ReplayDataRecorder.cs
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
public class ReplayDataRecorder : MonoBehaviour
{
	[SerializeField]
	private FrameCountRecorder refFrameCountRecorder;

	private static ReplayData replayData;

	void Start()
	{
		if( GameStatusInterfacer.GameMode == GameDefine.GameModeType.Replay )
		{
			enabled = false;
			return;
		}
		replayData = new ReplayData( Random.seed, GameStatusInterfacer.PlayerId, GameStatusInterfacer.StageId, GameStatusInterfacer.Difficulty );
	}

	public void AddUpKeyList()
	{
		replayData.AddUpKeyList( refFrameCountRecorder.CurrentFrameCount );
	}
	public void AddDownKeyList()
	{
		replayData.AddDownKeyList( refFrameCountRecorder.CurrentFrameCount );
	}
	public void AddLeftKeyList()
	{
		replayData.AddLeftKeyList( refFrameCountRecorder.CurrentFrameCount );
	}
	public void AddRightKeyList()
	{
		replayData.AddRightKeyList( refFrameCountRecorder.CurrentFrameCount );
	}
	public void AddFireKeyList()
	{
		replayData.AddUFireKeyList( refFrameCountRecorder.CurrentFrameCount );
	}
	public void AddSpecialKeyList()
	{
		replayData.AddSpecialKeyList( refFrameCountRecorder.CurrentFrameCount );
	}
	public void AddShiftKeyList()
	{
		replayData.AddShiftKeyList( refFrameCountRecorder.CurrentFrameCount );
	}

	public static void Save( int id )
	{
		replayData.End( GameDefine.StageType.Stage1 );
		SaveLoad.SaveReplayData( id, replayData );
	}
}
