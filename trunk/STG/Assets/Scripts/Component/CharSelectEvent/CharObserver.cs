/*===========================================================================*/
/*
*     * FileName    : CharObserver.cs
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
public class CharObserver : MonoBehaviour
{
	public const string Message = "OnModifyChar";

	public char Content
	{
		set
		{
			gameObject.BroadcastMessage( Message, value );
		}
	}
}
