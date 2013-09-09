/*===========================================================================*/
/*
*     * FileName    : EnemyShotLockFromGameLevel.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyShotLockFromGameLevel : EnemyShotCreateComponent
{
	protected override void TuningFromSet()
	{
		owner.isLock = element.min > GameManager.GameLevel;
	}
	protected override void TuningFromAdd()
	{
		TuningFromSet();
	}
}
