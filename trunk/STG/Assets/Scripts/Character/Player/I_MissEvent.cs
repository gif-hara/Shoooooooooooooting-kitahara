/*===========================================================================*/
/*
*     * FileName    : I_MissEvent.cs
*
*     * Description : ミス時のイベント定義.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

public interface I_MissEvent
{
	/// <summary>
	/// ミス処理
	/// </summary>
	void OnMiss();
}
