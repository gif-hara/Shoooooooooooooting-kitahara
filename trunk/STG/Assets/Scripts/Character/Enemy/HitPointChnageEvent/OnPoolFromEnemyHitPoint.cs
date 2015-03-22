/*===========================================================================*/
/*
*     * FileName    : OnPoolFromEnemyHitPoint.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// OnGameObjectDestroyOnHitPointChangeEventをキャッチしてプールするコンポーネント.
/// </summary>
public class OnPoolFromEnemyHitPoint : MonoBehaviour
{
	void OnGameObjectDestroyOnHitPointChangeEvent()
	{
		ObjectPool.Instance.ReleaseGameObject( gameObject );
	}
}
