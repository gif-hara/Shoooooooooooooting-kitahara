/*===========================================================================*/
/*
*     * FileName    : InputChangeChaseGameObject.cs
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
public class InputChangeChaseGameObject : MonoBehaviour
{
	[SerializeField]
	private ChaseGameObject refChaseGameObject;

	public Transform NormalChaseObject{ get{ return refNormalChaseObject; } }
	[SerializeField]
	private Transform refNormalChaseObject;

	public Transform ShiftChaseObject{ get{ return refShiftChaseObject; } }
	[SerializeField]
	private Transform refShiftChaseObject;

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
			refChaseGameObject.refChaseObject = refShiftChaseObject;
		}
		else
		{
			refChaseGameObject.refChaseObject = refNormalChaseObject;
		}
	}
}
