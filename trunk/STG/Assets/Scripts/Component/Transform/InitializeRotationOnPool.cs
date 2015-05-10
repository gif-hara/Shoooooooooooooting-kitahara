/*===========================================================================*/
/*
*     * FileName    : InitializeRotationOnPool.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ObjectPoolから再利用されたタイミングで回転量を初期化するコンポーネント.
/// </summary>
public class InitializeRotationOnPool : MonoBehaviour, I_Poolable
{
	[SerializeField]
	private Vector3 rotate;
	
	public void OnAwakeByPool( bool used )
	{
		transform.localRotation = Quaternion.Euler( rotate );
	}
	
	public void OnReleaseByPool()
	{
	}
}
