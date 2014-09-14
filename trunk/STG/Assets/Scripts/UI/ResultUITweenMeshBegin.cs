/*===========================================================================*/
/*
*     * FileName    : ResultUITweenMeshBegin.cs
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
public class ResultUITweenMeshBegin : ResultUIEffectExecuter
{
	[SerializeField]
	private TweenMeshColor refTweenMeshColor;

	protected override void Action ()
	{
		refTweenMeshColor.Begin();
	}
}
