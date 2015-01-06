/*===========================================================================*/
/*
*     * FileName    : ReplayDataLoader.cs
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
public class ReplayDataLoader : GameMonoBehaviour
{
	public class FrameLoad
	{
		public int Frame{ get{ return frame; } }
		private int frame;

		private int readIndex;

		public void NextRead( int frameCount, List<int> inputList )
		{
			if( !IsMatch( frameCount ) )	return;

			Read( inputList );
		}

		public void Read( List<int> inputList )
		{
			if( inputList.Count <= readIndex )
			{
				frame = -1;
				return;
			}

			frame = inputList[readIndex];
			readIndex++;
		}

		public bool IsMatch( int frameCount )
		{
			return frame == frameCount;
		}
	}
	private ReplayData replayData;
	
	private FrameLoad upKeyFrameLoader = new FrameLoad();

	private FrameLoad downKeyFrameLoader = new FrameLoad();

	private FrameLoad leftKeyFrameLoader = new FrameLoad();

	private FrameLoad rightKeyFrameLoader = new FrameLoad();

	private FrameLoad fireKeyFrameLoader = new FrameLoad();

	private FrameLoad specialKeyFrameLoader = new FrameLoad();

	private FrameLoad shiftKeyFrameLoader = new FrameLoad();

	public override void Awake ()
	{
		if( GameStatusInterfacer.GameMode != GameDefine.InputType.Replay )
		{
			enabled = false;
			return;
		}

		replayData = SaveLoad.LoadReplayData( GameStatusInterfacer.ReplayId );
		Random.seed = replayData.Seed;
		upKeyFrameLoader.Read( replayData.UpKeyList );
		downKeyFrameLoader.Read( replayData.DownKeyList );
		leftKeyFrameLoader.Read( replayData.LeftKeyList );
		rightKeyFrameLoader.Read( replayData.RightKeyList );
		fireKeyFrameLoader.Read( replayData.FireKeyList );
		specialKeyFrameLoader.Read( replayData.SpecialKeyList );
		shiftKeyFrameLoader.Read( replayData.ShiftKeyList );

	}

	public override void LateUpdate()
	{
		upKeyFrameLoader.NextRead( ReferenceManager.FrameCountRecorder.CurrentFrameCount, replayData.UpKeyList );
		downKeyFrameLoader.NextRead( ReferenceManager.FrameCountRecorder.CurrentFrameCount, replayData.DownKeyList );
		leftKeyFrameLoader.NextRead( ReferenceManager.FrameCountRecorder.CurrentFrameCount, replayData.LeftKeyList );
		rightKeyFrameLoader.NextRead( ReferenceManager.FrameCountRecorder.CurrentFrameCount, replayData.RightKeyList );
		fireKeyFrameLoader.NextRead( ReferenceManager.FrameCountRecorder.CurrentFrameCount, replayData.FireKeyList );
		specialKeyFrameLoader.NextRead( ReferenceManager.FrameCountRecorder.CurrentFrameCount, replayData.SpecialKeyList );
		shiftKeyFrameLoader.NextRead( ReferenceManager.FrameCountRecorder.CurrentFrameCount, replayData.ShiftKeyList );
	}

	public bool CanInputUpKey( int frameCount )
	{
		return upKeyFrameLoader.IsMatch( frameCount );
	}
	public bool CanInputDownKey( int frameCount )
	{
		return downKeyFrameLoader.IsMatch( frameCount );
	}
	public bool CanInputLeftKey( int frameCount )
	{
		return leftKeyFrameLoader.IsMatch( frameCount );
	}
	public bool CanInputRightKey( int frameCount )
	{
		return rightKeyFrameLoader.IsMatch( frameCount );
	}
	public bool CanInputFireKey( int frameCount )
	{
		return fireKeyFrameLoader.IsMatch( frameCount );
	}
	public bool CanInputSpecialKey( int frameCount )
	{
		return specialKeyFrameLoader.IsMatch( frameCount );
	}
	public bool CanInputShiftKey( int frameCount )
	{
		return shiftKeyFrameLoader.IsMatch( frameCount );
	}
}
