/*===========================================================================*/
/*
*     * FileName    : CommandEventContinue.cs
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
public class CommandEventContinue : GameMonoBehaviour
{
	void OnCommandEvent()
	{
		ReferenceManager.RefPlayerStatusManager.Continue();
		ReferenceManager.ScoreManager.Continue();
		ReferenceManager.refPlayerLayer.BroadcastMessage( GameDefine.ContinueMessage );
		ReferenceManager.refUILayer.BroadcastMessage( GameDefine.ContinueMessage );
		ReferenceManager.refUILayer.BroadcastMessage( GameDefine.EnableInputPauseMessage );
	}
}
