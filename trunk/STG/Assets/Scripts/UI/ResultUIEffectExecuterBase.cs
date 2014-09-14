/*===========================================================================*/
/*
*     * FileName    : ResultUIEffectExecuter.cs
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
public abstract class ResultUIEffectExecuter : GameMonoBehaviour
{
	[SerializeField]
	private int effectId;

	void OnEffectExecute( ResultUIManager.EffectData data )
	{
		if( this.effectId != data.effectId )
		{
			return;
		}
		data.receivedCount++;
		Action();
	}

	protected abstract void Action();
}
