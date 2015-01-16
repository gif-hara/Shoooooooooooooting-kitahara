/*===========================================================================*/
/*
*     * FileName    : CommandEventSaveReplayData.cs
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
public class CommandEventSaveReplayData : MonoBehaviour
{
	private int id;
	void OnCreatedReplayListElement( int id )
	{
		this.id = id;
	}
	void OnCommandEvent()
	{
		ReplayDataRecorder.Save( id );
	}
}
