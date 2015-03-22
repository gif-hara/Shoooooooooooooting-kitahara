/*===========================================================================*/
/*
*     * FileName    : EnemyForceDead.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 強制的に敵を死亡させるコンポーネント.
/// </summary>
public class EnemyForceDead : MonoBehaviour
{
	[SerializeField]
	private EnemyController refEnemy;

	[SerializeField]
	private int delay;

	// Update is called once per frame
	void Update ()
	{
		if( this.delay > 0 )
		{
			this.delay--;
			return;
		}

		refEnemy.ForceDead();
		enabled = false;
	}
}
