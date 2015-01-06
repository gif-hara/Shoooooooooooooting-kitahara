/*===========================================================================*/
/*
*     * FileName    : ReplayModeChangeChaseGameObject.cs
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
public class ReplayModeChangeChaseGameObject : GameMonoBehaviour
{
	[SerializeField]
	private ChaseGameObject refChaseGameObject;

	[SerializeField]
	private InputChangeChaseGameObject refInputChangeChaseGameObject;

	public override void Start ()
	{
		base.Start ();
		enabled = GameStatusInterfacer.GameMode == GameDefine.InputType.Replay;
	}
	
	public override void Update ()
	{
		if( ReferenceManager.ReplayDataLoader.CanInputShiftKey( ReferenceManager.FrameCountRecorder.CurrentFrameCount ) )
		{
			refChaseGameObject.ChangeChaseObject( refInputChangeChaseGameObject.ShiftChaseObject );
		}
		else
		{
			refChaseGameObject.ChangeChaseObject( refInputChangeChaseGameObject.NormalChaseObject );
		}
	}

	void OnPlayerSelectMode()
	{
		enabled = false;
	}
}
