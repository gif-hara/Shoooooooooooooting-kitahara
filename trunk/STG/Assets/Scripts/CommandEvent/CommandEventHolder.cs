/*===========================================================================*/
/*
*     * FileName    : CommandEventHolder.cs
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
public class CommandEventHolder : MonoBehaviour
{
	public CommandManager.InputEvent InputEvent{ get{ return refData; } }
	[SerializeField]
	private CommandManager.InputEvent refData;
}
