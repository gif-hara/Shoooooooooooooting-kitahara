/*===========================================================================*/
/*
*     * FileName    : EnemyShotLockFromReferenceNull.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class EnemyShotLockFromReferenceNull : EnemyShotCreateComponent
{
	/// <summary>
	/// Nullであるか監視するオブジェクト.
	/// </summary>
	[SerializeField]
	private GameObject refTarget;

	/// <summary>
	/// refTargetがNullなら弾を発射する.
	/// </summary>
	[SerializeField]
	private bool isNullActive;

	protected override void TuningFromSet()
	{
		owner.isLock = !((refTarget == null) == isNullActive);
	}
	protected override void TuningFromAdd()
	{
		TuningFromSet();
	}
}
