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
	[SerializeField]
	private float addSpecialPointMin;

	[SerializeField]
	private float addSpecialPointMax;
	
	[SerializeField]
	private int duration;

	public override void Update ()
	{
		base.Update ();
		duration--;
	}

	void OnEnemyCollision()
	{
		if( ReferenceManager.Instance.Player.IsSpecialMode )	return;

		var addPoint = duration > 0 ? addSpecialPointMax : addSpecialPointMin;
		ReferenceManager.Instance.RefPlayerStatusManager.AddSpecialPoint( addPoint );
	}
}
