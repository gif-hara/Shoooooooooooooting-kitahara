/*===========================================================================*/
/*
*     * FileName    : BombRangeShotRemove.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BombRangeShotRemove : GameMonoBehaviour
{
	[SerializeField]
	private float radius;
	
	// Update is called once per frame
	public override void Update()
	{
		GameManager.AddGameLevelExperienceFromEnemyShot( RangeShotRemove.Remove( cachedTransform, radius ) );
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere( transform.position, radius );
	}
}
