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
	private List<AddPositionGravity> refAddPositionGravityList;

	public int Id{ get{ return id; } }
	[SerializeField]
	private int id;

	public int AddScoreRate{ get{ return addScoreRate; } }
	[SerializeField]
	private int addScoreRate;

	[SerializeField]
	private PlayerChaseOnSpeed refChasePlayer;

	[SerializeField]
	private int completeFirstMoveDelay;

	private int cachedCompleteFirstMoveDelay;

	public override void Update ()
	{
		base.Update ();
		this.completeFirstMoveDelay--;
	}
	public override void OnAwakeByPool( bool used )
	{
		base.OnAwakeByPool( used );

		if( !used )
		{
			this.cachedCompleteFirstMoveDelay = this.completeFirstMoveDelay;
		}
		else
		{
			this.completeFirstMoveDelay = this.cachedCompleteFirstMoveDelay;
		}

		this.SetAllAddPositionGravityActive( true );
		this.refChasePlayer.enabled = false;
	}

	public override void StartChasePlayer ()
	{
		this.SetAllAddPositionGravityActive( false );
		refChasePlayer.enabled = true;
		Trans.LookAt( ReferenceManager.Player.Trans );
		Trans.localRotation = Quaternion.Euler( Vector3.forward * Trans.localRotation.z );
	}
	public override void OnPlayerCollide()
	{
		ScoreManager.EarnedStarItem( this );
		SoundManager.Instance.Play( "StarGet" );
	}

	public override bool IsFirstMove
	{
		get
		{
			return this.completeFirstMoveDelay > 0;
		}
	}

	private void SetAllAddPositionGravityActive( bool isActive )
	{
		for( int i=0,imax=this.refAddPositionGravityList.Count; i<imax; i++)
		{
			this.refAddPositionGravityList[i].enabled = isActive;
		}
	}
}
