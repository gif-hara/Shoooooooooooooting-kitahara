/*===========================================================================*/
/*
*     * FileName    : ResultUICountUp.cs
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
public class ResultUICountUp : ResultUIEffectExecuter
{
	[SerializeField]
	protected TextMesh refTextMesh;

	[SerializeField]
	private int starId;

	[SerializeField]
	protected int rate;

	[SerializeField]
	protected GameObject refResultManager;

	protected int currentCount = 0;

	protected int targetCount = 0;

	protected bool isUpdate = false;

	void Update()
	{
		if( !isUpdate )
		{
			return;
		}

		CountUp();
	}

	protected override void Action ()
	{
		isUpdate = true;
		targetCount = ReferenceManager.ScoreManager.EarnedStarItemList[starId];
	}

	protected virtual void CountUp()
	{
		if( currentCount >= targetCount )
		{
			isUpdate = false;
			refResultManager.SendMessage( ResultUIManager.CompleteMessage );
			return;
		}

		currentCount++;
		refTextMesh.text = (currentCount * rate).ToString();
	}
}
