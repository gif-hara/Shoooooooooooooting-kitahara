/*===========================================================================*/
/*
*     * FileName    : CommandEventDecideChar.cs
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
public class CommandEventDecideChar : MonoBehaviour
{
	[SerializeField]
	private CharListManager refCharListManager;

	void OnCommandEvent()
	{
		refCharListManager.AddChar();
	}
}
