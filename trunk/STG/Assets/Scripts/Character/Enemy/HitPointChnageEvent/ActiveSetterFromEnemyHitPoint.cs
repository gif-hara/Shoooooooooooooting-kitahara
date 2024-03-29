﻿/*===========================================================================*/
/*
*     * FileName    :ActiveSetterFromEnemyHitPoint.cs
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
public class ActiveSetterFromEnemyHitPoint : EventActionableFromEnemyHitPoint
{
	[SerializeField]
	private GameObject refActiveTarget;

	[SerializeField]
	private bool isActive = true;

	public override void Action ()
	{
		refActiveTarget.SetActive ( isActive );
	}
}
