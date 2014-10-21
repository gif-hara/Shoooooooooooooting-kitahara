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
		if( GameStatusInterfacer.GameMode == GameDefine.GameModeType.Replay )	return;
		if( PauseManager.Instance.IsPause )	return;
		
		if( MyInput.UpKey )
		{
			ReferenceManager.ReplayDataRecorder.AddUpKeyList();
		}
		else if( MyInput.DownKey )
		{
			ReferenceManager.ReplayDataRecorder.AddDownKeyList();
		}
		if( MyInput.LeftKey )
		{
			ReferenceManager.ReplayDataRecorder.AddLeftKeyList();
		}
		else if( MyInput.RightKey )
		{
			ReferenceManager.ReplayDataRecorder.AddRightKeyList();
		}
		if( MyInput.FireKey )
		{
			ReferenceManager.ReplayDataRecorder.AddFireKeyList();
		}
		if( MyInput.BombKey )
		{
			ReferenceManager.ReplayDataRecorder.AddSpecialKeyList();
		}
		if( MyInput.ShiftKey )
		{
			ReferenceManager.ReplayDataRecorder.AddShiftKeyList();
		}
	}

	void OnPlayerSelectMode()
	{
		enabled = false;
	}

}
