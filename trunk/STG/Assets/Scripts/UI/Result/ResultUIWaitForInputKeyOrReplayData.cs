/*===========================================================================*/
/*
*     * FileName    : ResultUIWaitForInputKeyOrReplayData.cs
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
public class ResultUIWaitForInputKeyOrReplayData : ResultUIEffectExecuter
{
	[SerializeField]
	private GameObject refResultManager;
	
	private bool isUpdate = false;

	public override void Update ()
	{
		base.Update ();

		if( !isUpdate )
		{
			return;
		}

		if( EndWait )
		{
			refResultManager.SendMessage( ResultUIManager.CompleteMessage );
			isUpdate = false;
		}

	}
	protected override void Action ()
	{
		isUpdate = true;
	}

	private bool EndWait
	{
		get
		{
			if( GameStatusInterfacer.GameMode == GameDefine.InputType.User )
			{
				return MyInput.FireKey;
			}
			else if( GameStatusInterfacer.GameMode == GameDefine.InputType.Replay )
			{
				return ReferenceManager.ReplayDataLoader.CanInputFireKey( ReferenceManager.FrameCountRecorder.CurrentFrameCount );
			}

			Debug.LogError( "GameMode Exception Error." );
			return false;
		}
	}
}
