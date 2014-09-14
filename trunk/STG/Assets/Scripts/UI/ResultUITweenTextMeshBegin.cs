/*===========================================================================*/
/*
*     * FileName    : ResultUITweenTextMeshBegin.cs
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
public class ResultUITweenTextMeshBegin : ResultUIEffectExecuter
{
	[SerializeField]
	private TweenTextMeshColor refTweenTextMeshColor;
	
	protected override void Action ()
	{
		refTweenTextMeshColor.Begin();
	}
}
