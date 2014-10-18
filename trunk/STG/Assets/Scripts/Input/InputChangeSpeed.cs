/*===========================================================================*/
/*
*     * FileName    : InputChangeSpeed.cs
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
public class InputChangeSpeed : MonoBehaviour
{
	[SerializeField]
	private ObjectMoveAcceptComponent refObjectMove;

	public float NormalSpeed{ get{ return this.normalSpeed; } }
	[SerializeField]
	private float normalSpeed;

	public float ShiftSpeed{ get{ return this.shiftSpeed; } }
	[SerializeField]
	private float shiftSpeed;

	void Update ()
	{
		if( PauseManager.Instance.IsPause )	return;
		
		InputShift();
	}

	void OnPlayerSelectMode()
	{
		enabled = false;
	}

	void OnReplayMode()
	{
		enabled = false;
	}

	private void InputShift()
	{
		if( Input.GetKey( KeyCode.LeftShift ) )
		{
			refObjectMove.ChangeSpeed( shiftSpeed );
		}
		else
		{
			refObjectMove.ChangeSpeed( normalSpeed );
		}
	}
}
