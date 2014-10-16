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
	
	[SerializeField]
	private Transform refNormalSyncRotationObject;
	
	[SerializeField]
	private Transform refShiftSyncRotationObject;
	
	void Update ()
	{
		InputShift();
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
