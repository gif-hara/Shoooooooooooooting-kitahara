/*===========================================================================*/
/*
*     * FileName    : ReplayModeChangeSyncRotation.cs
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
public class ReplayModeChangeSyncRotation : GameMonoBehaviour
{
	[SerializeField]
	private SyncRotation refSyncRotation;

	[SerializeField]
	private InputChangeSyncRotation refInputChangeSyncRotation;
	
	public override void Start ()
	{
		base.Start ();
		enabled = GameStatusInterfacer.GameMode == GameDefine.GameModeType.Replay;
	}
	
	public override void Update ()
	{
		if( ReferenceManager.ReplayDataLoader.CanInputShiftKey( ReferenceManager.FrameCountRecorder.CurrentFrameCount ) )
		{
			refSyncRotation.ChangeTarget( refInputChangeSyncRotation.ShiftSyncRotationObject );
		}
		else
		{
			refSyncRotation.ChangeTarget( refInputChangeSyncRotation.NormalSyncRotationObject );
		}
	}

	void OnPlayerSelectMode()
	{
		enabled = false;
	}

}