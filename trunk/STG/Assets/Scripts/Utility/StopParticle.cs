/*===========================================================================*/
/*
*     * FileName    : StopParticle.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class StopParticle : A_DelayEvent
{
	[SerializeField]
	private ParticleSystem refParticle;

	protected override void OnDelayEvent ()
	{
		this.refParticle.Stop(true);
	}
}
