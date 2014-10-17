/*===========================================================================*/
/*
*     * FileName    : PlayerCollider.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class PlayerCollider : A_Collider
{
	public Player refPlayer;
	
	public GameObject prefabCollisionEffect;
	
	public override void Awake()
	{
		base.Awake();

		if( ReferenceManager != null )
		{
			ReferenceManager.refCollisionManager.AddPlayerCollider( this );
		}

		InstantiateAsChild( transform, prefabCollisionEffect );
	}
	public override void OnCollision (A_Collider target)
	{
	}
	public override void Hit (A_Collider target)
	{
		base.Hit (target);
		refPlayer.Miss();
	}
	
	public override EType Type
	{
		get
		{
			return EType.Player;
		}
	}
	/// <summary>
	/// プレイヤーが無敵状態であるか？.
	/// </summary>
	/// <value>
	/// <c>true</c> if this instance is invincible player; otherwise, <c>false</c>.
	/// </value>
	public bool IsInvinciblePlayer
	{
		get
		{
			if( refPlayer == null )	return true;

			return refPlayer.IsInvincible;
		}
	}
}
