/*===========================================================================*/
/*
*     * FileName    : CommandEventAddCharSelectCursorId.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class CommandEventAddCharSelectCursorId : MonoBehaviour
{
	[SerializeField]
	private CharListManager refManager;

	[SerializeField]
	private int value;

	void OnCommandEvent()
	{
		refManager.AddCursorId( value );
	}
}
