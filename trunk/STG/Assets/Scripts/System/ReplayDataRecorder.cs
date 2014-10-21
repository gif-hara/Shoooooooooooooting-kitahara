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

	void Awake()
	{
		if( GameStatusInterfacer.GameMode == GameDefine.GameModeType.Replay )
		{
			enabled = false;
			return;
		}
		var now = System.DateTime.Now;
		var seed = (now.Millisecond * now.Second * now.Minute) % 19911016;
		Random.seed = seed;
		replayData = new ReplayData(
			seed,
			GameStatusInterfacer.PlayerId,
			GameStatusInterfacer.StageId,
			GameStatusInterfacer.Difficulty,
			GameStatusInterfacer.PlayStyle
			);
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
