/*===========================================================================*/
/*
*     * FileName    :ObjectMoveAttachFromEnemyHitPoint.cs
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
public class ObjectMoveAttachFromEnemyHitPoint : EventActionableFromEnemyHitPoint
{
	[SerializeField]
	private Transform refTrans;

	[SerializeField]
	private A_ObjectMove prefabObjectMove;

	public override void Action ()
	{
		ObjectMoveUtility.Attach( refTrans, prefabObjectMove );
	}
}
