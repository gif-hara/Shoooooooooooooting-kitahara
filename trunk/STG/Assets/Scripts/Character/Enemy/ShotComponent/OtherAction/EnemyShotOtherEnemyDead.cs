/*===========================================================================*/
/*
*     * FileName    :EnemyShotOtherEnemyDead.cs
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
public class EnemyShotOtherEnemyDead : A_EnemyShotOtherAction
{
	[SerializeField]
	private EnemyController refEnemy;

	public override void OtherAction ()
	{
		refEnemy.ForceDead();
	}
}
