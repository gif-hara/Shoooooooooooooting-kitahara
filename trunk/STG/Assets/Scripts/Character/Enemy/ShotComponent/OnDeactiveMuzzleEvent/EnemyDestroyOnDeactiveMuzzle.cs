/*===========================================================================*/
/*
*     * FileName    :EnemyDestroyOnDeactiveMuzzle.cs
*
*     * Description : 銃口が非アクティブになった状態に特定の敵を死亡させるコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 銃口が非アクティブになった状態に特定の敵を死亡させるコンポーネント.
/// </summary>
public class EnemyDestroyOnDeactiveMuzzle : GameMonoBehaviour
{
	[SerializeField]
	private int destroyEnemyId;

	void OnDeactiveMuzzle()
	{
		ReferenceManager.refEnemyLayer.BroadcastMessage( GameDefine.EnemyDestroyOnDeactiveMuzzleMessage, destroyEnemyId );
	}
}
