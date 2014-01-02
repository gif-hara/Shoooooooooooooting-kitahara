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
		ReferenceManager.refCollisionManager.AddPlayerCollider( this );
		InstantiateAsChild( transform, prefabCollisionEffect );
	}
	public override void OnCollision (A_Collider target)
	{
		if( target.Type == EType.Item )	return;

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
			return refPlayer.IsInvincible;
		}
	}
}
