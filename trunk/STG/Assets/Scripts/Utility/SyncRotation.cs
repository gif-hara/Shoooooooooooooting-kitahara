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

	[SerializeField]
	private Vector3 offset;

	private Transform cachedTransform;

	void Start()
	{
		this.cachedTransform = transform;
	}

	void LateUpdate ()
	{
		if( this.refTarget == null )	return;

		this.cachedTransform.rotation = refTarget.rotation;
		this.cachedTransform.rotation *= Quaternion.Euler( offset );
	}

	public void ChangeTarget( Transform target )
	{
		refTarget = target;
	}
}
