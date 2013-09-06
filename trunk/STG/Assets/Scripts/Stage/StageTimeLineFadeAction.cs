/*===========================================================================*/
/*
*     * FileName    : StageTimeLineFadeAction.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageTimeLineFadeAction : A_StageTimeLineActionable
{
	public Color fromColor;
	
	public Color toColor;
	
	public int duration;
	
	public override void Action()
	{
		ReferenceManager.refFadeManager.Begin( fromColor, toColor, duration );
		Destroy( gameObject );
	}
	
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] FadeAction", timeLine );
		}
	}
}
