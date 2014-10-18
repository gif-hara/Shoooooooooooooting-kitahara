/*===========================================================================*/
/*
*     * FileName    : ReplayModeMove.cs
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
public class ReplayModeMove : GameMonoBehaviour
{
	[SerializeField]
	private ObjectMoveAcceptComponent refObjectMove;
	
	public override void Start ()
	{
		base.Start ();
		enabled = GameStatusInterfacer.GameMode == GameDefine.GameModeType.Replay;
	}
	
	public override void Update ()
	{
		if( ReferenceManager.ReplayDataLoader.CanInputUpKey( ReferenceManager.FrameCountRecorder.CurrentFrameCount ) )
		{
			refObjectMove.Up();
		}
		else if( ReferenceManager.ReplayDataLoader.CanInputDownKey( ReferenceManager.FrameCountRecorder.CurrentFrameCount ) )
		{
			refObjectMove.Down();
		}
		if( ReferenceManager.ReplayDataLoader.CanInputLeftKey( ReferenceManager.FrameCountRecorder.CurrentFrameCount ) )
		{
			refObjectMove.Left();
		}
		else if( ReferenceManager.ReplayDataLoader.CanInputRightKey( ReferenceManager.FrameCountRecorder.CurrentFrameCount ) )
		{
			refObjectMove.Right();
		}
	}

	void OnPlayerSelectMode()
	{
		enabled = false;
	}

}
