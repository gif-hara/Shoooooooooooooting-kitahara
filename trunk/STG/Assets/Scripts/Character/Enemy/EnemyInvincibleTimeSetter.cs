/*===========================================================================*/
/*
*     * FileName    :EnemyInvincibleTimeSetter.cs
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
public class EnemyInvincibleTimeSetter : MonoBehaviour
{
	[SerializeField]
	private EnemyController refEnemy;

	[SerializeField]
	private int invincibleTime;

	void Start ()
	{
		refEnemy.invincibleTimer = invincibleTime;
	}
}
