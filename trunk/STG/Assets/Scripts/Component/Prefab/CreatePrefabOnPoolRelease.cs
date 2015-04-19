/*===========================================================================*/
/*
*     * FileName    : CreatePrefabOnPoolRelease.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ObjectPoolのOnRelease時にプレハブを生成するコンポーネント.
/// </summary>
public class CreatePrefabOnPoolRelease : MonoBehaviour, I_Poolable
{
	/// <summary>
	/// 生成するプレハブ.
	/// </summary>
	public GameObject prefab;
	
	/// <summary>
	/// 生成する座標を持つオブジェクト参照.
	/// </summary>
	public Transform refTarget;

	public void OnAwakeByPool( bool used )
	{
	}

	public void OnReleaseByPool()
	{
		ObjectPool.Instance.GetGameObject( prefab, refTarget.position, prefab.transform.rotation );
	}
}
