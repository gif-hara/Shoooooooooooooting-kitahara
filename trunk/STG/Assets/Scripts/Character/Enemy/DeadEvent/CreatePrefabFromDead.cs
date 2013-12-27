//================================================
/*!
    @file   CreatePrefabFromDead.cs

    @brief  敵死亡時にプレハブを生成するコンポーネント.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵死亡時にプレハブを生成するコンポーネント.
/// </summary>
public class CreatePrefabFromDead : GameMonoBehaviour, I_DeadEvent
{
	[SerializeField]
	private GameObject prefab;

	/// <summary>
	/// 死亡処理.
	/// </summary>
	public void OnDead()
	{
		var obj = InstantiateAsChild( ReferenceManager.refEffectLayer, prefab );
		obj.transform.position = transform.position;
	}
}
