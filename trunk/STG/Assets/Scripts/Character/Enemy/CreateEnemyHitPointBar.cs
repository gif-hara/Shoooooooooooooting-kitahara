/*===========================================================================*/
/*
*     * FileName    : CreateEnemyHitPointBar.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CreateEnemyHitPointBar : GameMonoBehaviour
{
	public EnemyController refEnemy;
	
	private UIEnemyHitPointBar refBarConrtoller;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		refBarConrtoller = InstantiateAsChild( ReferenceManager.refUILayer, ReferenceManager.prefabEnemyHitPointBar ).GetComponent<UIEnemyHitPointBar>();
		refBarConrtoller.Initialize( refEnemy );
	}
	void OnDestroy()
	{
		if( refBarConrtoller == null )	return;
		
		refBarConrtoller.EndEffect();
	}
}
