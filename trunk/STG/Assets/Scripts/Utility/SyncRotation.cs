/*===========================================================================*/
/*
*     * FileName    : SyncRotation.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 指定したオブジェクトの回転量と同期を取るコンポーネント.
/// </summary>
public class SyncRotation : MonoBehaviour
{
	[SerializeField]
	private Transform refTarget;

	private Transform cachedTransform;

	void Start()
	{
		this.cachedTransform = transform;
	}

	void LateUpdate ()
	{
		this.cachedTransform.rotation = refTarget.rotation;
	}
}
