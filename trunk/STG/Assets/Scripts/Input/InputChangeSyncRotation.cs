/*===========================================================================*/
/*
*     * FileName    : InputChangeSyncRotation.cs
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
public class InputChangeSyncRotation : MonoBehaviour
{
	[SerializeField]
	private SyncRotation refSyncRotation;

	public Transform NormalSyncRotationObject{ get{ return refNormalSyncRotationObject; } }
	[SerializeField]
	private Transform refNormalSyncRotationObject;
	
	public Transform ShiftSyncRotationObject{ get{ return refShiftSyncRotationObject; } }
	[SerializeField]
	private Transform refShiftSyncRotationObject;
	
	void Update ()
	{
		if( PauseManager.Instance.IsPause )	return;
		
		InputShift();
	}

	void OnReplayMode()
	{
		enabled = false;
	}
	
	private void InputShift()
	{
		if( Input.GetKey( KeyCode.LeftShift ) )
		{
			refSyncRotation.ChangeTarget( refShiftSyncRotationObject );
		}
		else
		{
			refSyncRotation.ChangeTarget( refNormalSyncRotationObject );
		}
	}
}
