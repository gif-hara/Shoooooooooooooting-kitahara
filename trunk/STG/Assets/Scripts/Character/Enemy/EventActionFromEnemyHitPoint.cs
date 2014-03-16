/*===========================================================================*/
/*
*     * FileName    :EventActionFromEnemyHitPoint.cs
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
public class EventActionFromEnemyHitPoint : GameMonoBehaviour
{
	[SerializeField]
	private EnemyController refEnemy;
	
	[SerializeField]
	private int changeHitPoint;

	private List<EventActionableFromEnemyHitPoint> refActionableList;

	public override void Start()
	{
		refActionableList = new List<EventActionableFromEnemyHitPoint>( GetComponents<EventActionableFromEnemyHitPoint>() );
	}
	
	public override void Update ()
	{
		if( refEnemy.Hp <= changeHitPoint )
		{
			refActionableList.ForEach( a => a.Action() );
			enabled = false;
		}
	}
}
