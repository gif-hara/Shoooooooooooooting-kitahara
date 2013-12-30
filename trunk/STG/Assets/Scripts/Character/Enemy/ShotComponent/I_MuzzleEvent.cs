/*===========================================================================*/
/*
*     * FileName    :I_MuzzleEventActinable.cs
*
*     * Description : 銃口イベント基底クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// 銃口イベント基底クラス.
/// </summary>
public interface I_MuzzleEventActinable
{
	/// <summary>
	/// 銃口がアクティブになった際のイベント.
	/// </summary>
	void OnActiveMuzzle();
}
