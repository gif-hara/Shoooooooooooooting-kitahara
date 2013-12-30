/*===========================================================================*/
/*
*     * FileName    :I_EnemyShotCreatorEvent.cs
*
*     * Description : EnemyShotCreatorのメッセージを受け取る基底クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// EnemyShotCreatorのメッセージを受け取る基底クラス.
/// </summary>
public interface I_EnemyShotCreatorEvent
{
	/// <summary>
	/// 全弾出し切った際のメッセージ.
	/// </summary>
	void OnFreezeEnemyShotCreator();
}
