/*===========================================================================*/
/*
*     * FileName    :EnemyShotLockFromRotateY.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class EnemyShotLockFromRotateY : EnemyShotCreateComponent
{
	protected override void TuningFromSet()
	{
		owner.isLock = Trans.rotation.eulerAngles.y >= 90.0f && Trans.rotation.eulerAngles.y <= 270.0f;
	}
	protected override void TuningFromAdd()
	{
		TuningFromSet();
	}
}
