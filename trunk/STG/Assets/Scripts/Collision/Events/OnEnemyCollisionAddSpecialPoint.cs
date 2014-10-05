/*===========================================================================*/
/*
*     * FileName    : OnEnemyCollisionAddSpecialPoint.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵と衝突した際のイベントをキャッチしてSPを加算するコンポーネント.
/// </summary>
public class OnEnemyCollisionAddSpecialPoint : GameMonoBehaviour
{
	/// <summary>
	/// 敵と衝突した際に加算されるSP.
	/// </summary>
	[SerializeField]
	private float addSpecialPoint;

	void OnEnemyCollision()
	{
		if( ReferenceManager.Instance.Player.IsSpecialMode )	return;

		ReferenceManager.Instance.RefPlayerStatusManager.AddSpecialPoint( addSpecialPoint );
	}
}
