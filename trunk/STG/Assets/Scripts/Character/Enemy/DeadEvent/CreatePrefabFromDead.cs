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
	public GameObject prefab;

	[SerializeField]
	private GameDefine.CreateType createType = GameDefine.CreateType.Pool;

	/// <summary>
	/// 死亡処理.
	/// </summary>
	public void OnDead()
	{
		if( createType == GameDefine.CreateType.Instantiate )
		{
			Instantiate( prefab, transform.position, prefab.transform.rotation );
		}
		else
		{
			ObjectPool.Instance.GetGameObject( prefab, transform.position, prefab.transform.rotation );
		}
	}
}
