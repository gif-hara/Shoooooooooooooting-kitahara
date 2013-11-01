/*===========================================================================*/
/*
*     * FileName    : BombAllShotRemove.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BombAllShotRemove : GameMonoBehaviour
{
	// Update is called once per frame
	public override void Update()
	{
		GameManager.AddGameLevelExperienceFromEnemyShot( AllShotRemove.AllRemove() );
	}
}
