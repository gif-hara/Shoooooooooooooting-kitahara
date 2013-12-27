//================================================
/*!
    @file   DeadEventAllEnemyShotDestroy.cs

    @brief  敵死亡時に敵弾全て死亡させるコンポーネント.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵死亡時に敵弾全て死亡させるコンポーネント.
/// </summary>
public class DeadEventAllEnemyShotDestroy : GameMonoBehaviour, I_DeadEvent
{
	/// <summary>
	/// 死亡処理.
	/// </summary>
	public void OnDead()
	{
		ReferenceManager.refCollisionManager.AllDestroyEnemyShot();
	}
}
