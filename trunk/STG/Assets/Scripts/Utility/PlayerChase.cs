/*===========================================================================*/
/*
*     * FileName    : PlayerChase.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerChase : GameMonoBehaviour
{
	public Vector3 fixedPosition;
	
	public override void LateUpdate()
	{
		base.LateUpdate();
		
		var playerPos = ReferenceManager.Player.cachedTransform.position;
		cachedTransform.position = playerPos + fixedPosition;
	}
}
