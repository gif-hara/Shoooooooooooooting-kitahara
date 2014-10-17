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

	[SerializeField]
	private float normalSpeed;

	[SerializeField]
	private float shiftSpeed;

	void Update ()
	{
		InputShift();
	}

	void OnPlayerSelectMode()
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
