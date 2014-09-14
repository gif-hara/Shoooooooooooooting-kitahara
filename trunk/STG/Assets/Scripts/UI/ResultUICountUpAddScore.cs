/*===========================================================================*/
/*
*     * FileName    : ResultUICountUpAddScore.cs
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
public class ResultUICountUpAddScore : ResultUICountUp
{
	protected override void CountUp ()
	{
		if( currentCount >= targetCount )
		{
			isUpdate = false;
			refResultManager.SendMessage( ResultUIManager.CompleteMessage );
			return;
		}
		
		currentCount++;
		refTextMesh.text = (currentCount * rate).ToString();
		ReferenceManager.ScoreManager.AddScore( (ulong)rate );
	}
}
