/*===========================================================================*/
/*
*     * FileName    : InputRecorder.cs
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
public class InputRecorder : GameMonoBehaviour
{
	public override void Update ()
	{
		if( Input.GetKey( KeyCode.UpArrow ) )
		{
			ReferenceManager.ReplayDataRecorder.AddUpKeyList();
		}
		else if( Input.GetKey( KeyCode.DownArrow ) )
		{
			ReferenceManager.ReplayDataRecorder.AddDownKeyList();
		}
		if( Input.GetKey( KeyCode.LeftArrow ) )
		{
			ReferenceManager.ReplayDataRecorder.AddLeftKeyList();
		}
		else if( Input.GetKey( KeyCode.RightArrow ) )
		{
			ReferenceManager.ReplayDataRecorder.AddRightKeyList();
		}
		if( Input.GetKey( KeyCode.Z ) )
		{
			ReferenceManager.ReplayDataRecorder.AddFireKeyList();
		}
		if( Input.GetKeyDown( KeyCode.X ) )
		{
			ReferenceManager.ReplayDataRecorder.AddSpecialKeyList();
		}
		if( Input.GetKey( KeyCode.LeftShift ) )
		{
			ReferenceManager.ReplayDataRecorder.AddShiftKeyList();
		}
	}
}
