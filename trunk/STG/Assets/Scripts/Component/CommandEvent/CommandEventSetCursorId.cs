/*===========================================================================*/
/*
*     * FileName    : CommandEventSetCursorId.cs
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
public class CommandEventSetCursorId : MonoBehaviour
{
	[SerializeField]
	private CommandManager refCommandManager;

	[SerializeField]
	private int value;

	void OnCommandEvent()
	{
		refCommandManager.SetCursorId( value );
	}
}
