/*===========================================================================*/
/*
*     * FileName    : ResultUIInitializeNumberLabel.cs
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
public class ResultUIInitializeNumberLabel : ResultUIEffectExecuter
{
	[SerializeField]
	private TextMesh refTextMesh;

	[SerializeField]
	private GameObject refResultManager;

	protected override void Action ()
	{
		refTextMesh.text = "0";
		refResultManager.SendMessage( ResultUIManager.CompleteMessage );
	}
}
