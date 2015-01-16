/*===========================================================================*/
/*
*     * FileName    : InputSpecialMode.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class InputSpecialMode : MonoBehaviour
{
	[SerializeField]
	private Player refPlayer;
	
	// Update is called once per frame
	void Update()
	{
		if( PauseManager.Instance.IsPause )	return;
		
		UpdateIsValid();
	}

	void OnPlayerSelectMode()
	{
		enabled = false;
	}

	void OnReplayMode()
	{
		enabled = false;
	}

	private void UpdateIsValid()
	{
		if( MyInput.BombKeyDown )
		{
			refPlayer.StartSpecialMode();
		}
	}
}
