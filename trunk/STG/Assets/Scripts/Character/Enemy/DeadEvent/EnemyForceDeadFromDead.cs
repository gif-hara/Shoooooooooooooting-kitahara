//================================================
/*!
    @file   EnemyForceDeadFromDead.cs

    @brief  .敵死亡時に指定した敵も強制的に死亡させるコンポーネント

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵死亡時に指定した敵も強制的に死亡させるコンポーネント.
/// </summary>
public class EnemyForceDeadFromDead : GameMonoBehaviour, I_DeadEvent
{
	[SerializeField]
	private EnemyController	refEnemy;

	/// <summary>
	/// 死亡処理.
	/// </summary>
	public void OnDead()
	{
		if( refEnemy == null )	return;

		refEnemy.Trans.parent = null;
		refEnemy.ForceDead();
	}
}
