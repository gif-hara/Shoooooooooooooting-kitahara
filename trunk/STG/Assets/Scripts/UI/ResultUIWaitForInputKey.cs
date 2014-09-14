/*===========================================================================*/
/*
*     * FileName    : ResultUIWaitForInputKey.cs
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
public class ResultUIWaitForInputKey : ResultUIEffectExecuter
{
	[SerializeField]
	private GameObject refResultManager;
	
	private bool isUpdate = false;

	public override void Update ()
	{
		base.Update ();

		if( !isUpdate )
		{
			return;
		}

		if( Input.GetKeyDown( KeyCode.Z ) )
		{
			refResultManager.SendMessage( ResultUIManager.CompleteMessage );
			isUpdate = false;
		}

	}
	protected override void Action ()
	{
		isUpdate = true;
	}
}
