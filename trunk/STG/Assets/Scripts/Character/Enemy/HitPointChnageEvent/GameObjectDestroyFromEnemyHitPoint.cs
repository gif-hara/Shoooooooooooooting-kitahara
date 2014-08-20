/*===========================================================================*/
/*
*     * FileName    : GameObjectDestroyFromEnemyHitPoint.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MyProject
{
	/// <summary>
	/// 的ヒットポイントイベント時にゲームオブジェクトを死亡させるコンポーネント.
	/// </summary>
	public class GameObjectDestroyFromEnemyHitPoint : EventActionableFromEnemyHitPoint
	{
		[SerializeField]
		private int delay;

		public override void Action ()
		{
			FrameRateUtility.StartCoroutine( delay, () =>
			{
				ReferenceManager.Instance.MainObjectHolder.BroadcastMessage( GameDefine.GameObjectDestroyOnHitPointChangeEventMessage, SendMessageOptions.DontRequireReceiver );
			});
		}
	}
}
