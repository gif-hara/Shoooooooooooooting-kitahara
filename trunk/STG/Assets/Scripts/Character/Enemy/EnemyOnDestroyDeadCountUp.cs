/*===========================================================================*/
/*
*     * FileName    :EnemyOnDestroyDeadCountUp.cs
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
public class EnemyOnDestroyDeadCountUp : GameMonoBehaviour
{
	[SerializeField]
	private EnemyController refEnemy;

	void OnDestroy()
	{
		GameManager.DestroyEnemy( refEnemy.Id );
		Debug.Log( "EnemyOnDestroyDeadCountUp.OnDestroy()" );
	}
}
