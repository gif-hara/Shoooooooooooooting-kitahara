/*===========================================================================*/
/*
*     * FileName    : ResultUITweenPositionBegin.cs
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
public class ResultUITweenPositionBegin : ResultUIEffectExecuter
{
	[SerializeField]
	private TweenPosition refTweenPosition;

	protected override void Action ()
	{
		refTweenPosition.transform.localPosition = refTweenPosition.from;
		refTweenPosition.Play( true );
	}
}
