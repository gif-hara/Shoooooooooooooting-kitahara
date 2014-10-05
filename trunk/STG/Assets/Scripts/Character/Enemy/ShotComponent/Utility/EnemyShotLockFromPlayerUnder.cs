/*===========================================================================*/
/*
*     * FileName    : EnemyShotLockFromPlayerUnder.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyShotLockFromPlayerUnder : EnemyShotCreateComponent
{
	/// <summary>
	/// 親オブジェクト参照.
	/// </summary>
	public Transform refParent;
	
	/// <summary>
	/// 判定のY座標修正値.
	/// </summary>
	public float fixedY;
	
	protected override void TuningFromSet()
	{
		var parentY = refParent.position.y + fixedY;
		owner.isPlayerTop = parentY > ReferenceManager.Player.cachedTransform.position.y;
	}
	
	protected override void TuningFromAdd()
	{
		TuningFromSet();
	}
}
