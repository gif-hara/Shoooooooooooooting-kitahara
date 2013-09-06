/*===========================================================================*/
/*
*     * FileName    : Barrier.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Barrier : GameMonoBehaviour
{
	public ParticleSystem refParticle;
	
	public BarrierCollider refCollider;
	
	private Player player;
	
	// Use this for initialization
	void Start()
	{
		player = ReferenceManager.refPlayer;
	}

	// Update is called once per frame
	void Update()
	{
		UpdatePosition();
		UpdateParticleScale();
	}
	
	private void UpdatePosition()
	{
		Trans.position = Vector3.Lerp( Trans.position, ReferenceManager.refPlayer.Trans.position, 0.05f );
	}
	
	private void UpdateParticleScale()
	{
		refCollider.radius = (player.CurrentBarrierSize) / 2.0f;
		if( refParticle != null )
		{
			refParticle.startSize = refCollider.radius * 2.0f;
		}
	}
}
