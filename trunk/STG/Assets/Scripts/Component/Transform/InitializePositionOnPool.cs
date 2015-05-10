/*===========================================================================*/
/*
*     * FileName    : InitializePositionOnPool.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ObjectPoolから再利用されたタイミングで座標を初期化するコンポーネント.
/// </summary>
public class InitializePositionOnPool : MonoBehaviour, I_Poolable
{
	[SerializeField]
	private Vector3 position;

	public void OnAwakeByPool( bool used )
	{
		transform.localPosition = position;
	}

	public void OnReleaseByPool()
	{
	}
}
