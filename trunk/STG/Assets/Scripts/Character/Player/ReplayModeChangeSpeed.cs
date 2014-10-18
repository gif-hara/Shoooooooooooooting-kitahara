/*===========================================================================*/
/*
*     * FileName    : ReplayModeChangeSpeed.cs
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
public class ReplayModeChangeSpeed : GameMonoBehaviour
{
	[SerializeField]
	private ObjectMoveAcceptComponent refObjectMove;

	[SerializeField]
	private InputChangeSpeed refInputChangeSpeed;
	
	public override void Start ()
	{
		base.Start ();
		enabled = GameStatusInterfacer.GameMode == GameDefine.GameModeType.Replay;
	}
	
	public override void Update ()
	{
		if( ReferenceManager.ReplayDataLoader.CanInputShiftKey( ReferenceManager.FrameCountRecorder.CurrentFrameCount ) )
		{
			refObjectMove.ChangeSpeed( refInputChangeSpeed.ShiftSpeed );
		}
		else
		{
			refObjectMove.ChangeSpeed( refInputChangeSpeed.NormalSpeed );
		}
	}

	void OnPlayerSelectMode()
	{
		enabled = false;
	}
}
