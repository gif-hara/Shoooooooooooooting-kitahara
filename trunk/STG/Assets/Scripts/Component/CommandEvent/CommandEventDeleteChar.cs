/*===========================================================================*/
/*
*     * FileName    : CommandEventDeleteChar.cs
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
public class CommandEventDeleteChar : MonoBehaviour
{
	[SerializeField]
	private CharListManager refManager;

	void OnCommandEvent()
	{
		refManager.DeleteChar();
	}
}
