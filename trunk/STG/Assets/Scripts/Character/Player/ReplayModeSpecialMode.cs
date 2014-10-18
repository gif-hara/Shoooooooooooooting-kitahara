/*===========================================================================*/
/*
*     * FileName    : ReplayModeSpecialMode.cs
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
public class ReplayModeSpecialMode : GameMonoBehaviour
{
	[SerializeField]
	private Player refPlayer;
	
	public override void Start ()
	{
		base.Start ();
		enabled = GameStatusInterfacer.GameMode == GameDefine.GameModeType.Replay;
	}
	
	public override void Update ()
	{
		if( ReferenceManager.ReplayDataLoader.CanInputSpecialKey( ReferenceManager.FrameCountRecorder.CurrentFrameCount ) )
		{
			refPlayer.StartSpecialMode();
		}
	}

	void OnPlayerSelectMode()
	{
		enabled = false;
	}

}
