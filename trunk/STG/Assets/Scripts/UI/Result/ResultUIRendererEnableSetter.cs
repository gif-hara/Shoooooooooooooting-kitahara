/*===========================================================================*/
/*
*     * FileName    : ResultUIRendererEnableSetter.cs
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
public class ResultUIRendererEnableSetter : ResultUIEffectExecuter
{
	[SerializeField]
	private Renderer refRenderer;

	[SerializeField]
	private bool isActive;

	[SerializeField]
	private int delay;

	[SerializeField]
	private GameObject refResultManager;

	protected override void Action ()
	{
		if( delay == 0 )
		{
			ChangeEnabled();
		}
		else
		{
			FrameRateUtility.StartCoroutine( delay, ChangeEnabled );
		}
	}

	private void ChangeEnabled()
	{
		refRenderer.enabled = isActive;
		refResultManager.SendMessage( ResultUIManager.CompleteMessage );
	}
}
