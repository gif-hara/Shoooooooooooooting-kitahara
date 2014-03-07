/*===========================================================================*/
/*
*     * FileName    :EnemyHitPointInitialize.cs
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
public class EnemyHitPointInitialize : MonoBehaviour
{
	[SerializeField]
	private EnemyController refEnemy;

	[SerializeField]
	private int hitPoint;

	void Start()
	{
		refEnemy.InitHitPoint( hitPoint );
	}
}
