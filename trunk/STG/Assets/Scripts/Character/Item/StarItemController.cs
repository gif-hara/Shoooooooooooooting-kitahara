/*===========================================================================*/
/*
*     * FileName    :StarItemController.cs
*
*     * Description : .
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
public class StarItemController : A_ItemController
{
	[SerializeField]
	private PlayerChaseOnSpeed refChasePlayer;

	public override void StartChasePlayer ()
	{
		refFirstTween.enabled = false;
		refFallTween.enabled = false;
		refChasePlayer.enabled = true;
		Trans.LookAt( ReferenceManager.Instance.refPlayer.Trans );
		Trans.localRotation = Quaternion.Euler( Vector3.forward * Trans.localRotation.z );
	}
	public override void OnPlayerCollide()
	{
		ScoreManager.EarnedStarItem();
	}
}
