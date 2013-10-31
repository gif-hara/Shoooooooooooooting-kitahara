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
	/// <summary>
	/// パーティクル参照.
	/// </summary>
	[SerializeField]
	private ParticleSystem refParticle;
	
	/// <summary>
	/// バリアコライダー参照.
	/// </summary>
	[SerializeField]
	private BarrierCollider refCollider;
	
	/// <summary>
	/// 発動に必要なSPポイント.
	/// </summary>
	public int NeedPoint{ get{ return needPoint; } }
	[SerializeField]
	private int needPoint;
	
	/// <summary>
	/// 効果時間.
	/// </summary>
	[SerializeField]
	private int duration;
	
	/// <summary>
	/// バリア最大値.
	/// </summary>
	[SerializeField]
	private float max;
		
	/// <summary>
	/// サイズアニメーションカーブ.
	/// </summary>
	[SerializeField]
	private AnimationCurve sizeAnimation;
	
	/// <summary>
	/// プレイヤー参照.
	/// </summary>
	private Player player;
	
	/// <summary>
	/// 現在の効果時間.
	/// </summary>
	private int currentDuration = 0;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		player = ReferenceManager.refPlayer;
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		UpdatePosition();
		UpdateParticleScale();
		
		if( currentDuration >= duration )
		{
			Destroy( gameObject );
			player.EndSpecialMode();
		}
		
		currentDuration++;
	}
	/// <summary>
	/// 発動可能か？.
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance can execute the specified player; otherwise, <c>false</c>.
	/// </returns>
	/// <param name='player'>
	/// If set to <c>true</c> player.
	/// </param>
	public bool CanExecute( Player player )
	{
		return player.CurrentSpecialPoint >= needPoint;
	}
	/// <summary>
	/// 座標の更新処理.
	/// </summary>
	private void UpdatePosition()
	{
		Trans.position = player.Trans.position;
	}
	/// <summary>
	/// パーティクルのスケール値の更新処理.
	/// </summary>
	private void UpdateParticleScale()
	{
		refCollider.radius = (sizeAnimation.Evaluate( (float)currentDuration / duration ) * max) / 2.0f;
		if( refParticle != null )
		{
			refParticle.startSize = refCollider.radius * 2.0f;
		}
	}
}
