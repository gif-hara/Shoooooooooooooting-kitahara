/*===========================================================================*/
/*
*     * FileName    : RandomRotation.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ランダムで回転量を設定するコンポーネント.
/// </summary>
public class RandomRotation : MonoBehaviour
{
	[SerializeField]
	private Transform refTarget;

	[SerializeField]
	private Vector3 min;

	[SerializeField]
	private Vector3 max;

	void Start ()
	{
		refTarget.localRotation = Quaternion.Euler( new Vector3(
			Random.Range( min.x, max.x ),
			Random.Range( min.y, max.y ),
			Random.Range( min.z, max.z )
			) );
	}
}
