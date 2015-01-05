/*===========================================================================*/
/*
*     * FileName    : ResultUIPlaySE.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class ResultUIPlaySE : ResultUIEffectExecuter
{
	[SerializeField]
	private string label;

	protected override void Action ()
	{
		SoundManager.Instance.Play( label );
	}
}
