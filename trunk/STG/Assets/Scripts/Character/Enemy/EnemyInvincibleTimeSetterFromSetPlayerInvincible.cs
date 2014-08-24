/*===========================================================================*/
/*
*     * FileName    : EnemyInvincibleTimeSetterFromSetPlayerInvincible.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// プレイヤーの無敵時間設定のイベントをキャッチして敵の無敵時間を設定するコンポーネント.
/// </summary>
public class EnemyInvincibleTimeSetterFromSetPlayerInvincible : MonoBehaviour
{
	[SerializeField]
	private EnemyController refTarget;

	/// <summary>
	/// 追加で加算される値.
	/// </summary>
	[SerializeField]
	private int additionValue;

	void OnSetPlayerInvincible( int invincibleTime )
	{
		this.refTarget.AddInvincible( invincibleTime + this.additionValue );
	}
}
