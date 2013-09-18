/*===========================================================================*/
/*
*     * FileName    : EnemyDestroyAllShotRemove.cs
*
*     * Description : アタッチしたオブジェクトが死亡したら敵弾すべて削除するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyDestroyAllShotRemove : GameMonoBehaviour
{
	void OnDestroy()
	{
		if( ReferenceManager.refEnemyShotLayer == null )	return;
		
		var shotList = ReferenceManager.refEnemyShotLayer.GetComponentsInChildren<EnemyShot>();
		foreach( var shot in shotList )
		{
			shot.Explosion();
		}
	}
}
