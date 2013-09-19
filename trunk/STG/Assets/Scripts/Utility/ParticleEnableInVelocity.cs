/*===========================================================================*/
/*
*     * FileName    : ParticleEnableInVelocity.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ParticleEnableInVelocity : MonoBehaviourExtension
{
	/// <summary>
	/// 移動検知を行うオブジェクト参照.
	/// </summary>
	public Transform refTarget;
	
	/// <summary>
	/// 左へ移動した時に有効化されるパーティクルリスト.
	/// </summary>
	public List<ParticleSystem> refLeftMoveEnableParticleList;
	/// <summary>
	/// 右へ移動した時に有効化されるパーティクルリスト.
	/// </summary>
	public List<ParticleSystem> refRightMoveEnableParticleList;
	/// <summary>
	/// 上へ移動した時に有効化されるパーティクルリスト.
	/// </summary>
	public List<ParticleSystem> refUpMoveEnableParticleList;
	/// <summary>
	/// 下へ移動した時に有効化されるパーティクルリスト.
	/// </summary>
	public List<ParticleSystem> refDownMoveEnableParticleList;
	
	/// <summary>
	/// 前フレームの座標.
	/// </summary>
	private Vector3 oldPosition;
	
	/// <summary>
	/// 各方向のパーティクル有効処理を行ったか.
	/// </summary>
	private bool isLeft = false, isRight = false, isUp = false, isDown = false;
	
	public override void Update()
	{
		base.Update();
		
		var position = refTarget.position;
		
		var subX = position.x - oldPosition.x;
		if( subX > 0 && !isRight )
		{
			refRightMoveEnableParticleList.ForEach( (obj) => obj.Play() );
			refLeftMoveEnableParticleList.ForEach( (obj) => obj.Stop() );
			isRight = true;
			isLeft = false;
		}
		else if( subX < 0 && !isLeft )
		{
			refLeftMoveEnableParticleList.ForEach( (obj) => obj.Play() );
			refRightMoveEnableParticleList.ForEach( (obj) => obj.Stop() );
			isLeft = true;
			isRight = false;
		}
		if( subX == 0.0f )
		{
			refLeftMoveEnableParticleList.ForEach( (obj) => obj.Stop() );
			refRightMoveEnableParticleList.ForEach( (obj) => obj.Stop() );
			isRight = false;
			isLeft = false;
		}
		
		var subY = position.y - oldPosition.y;
		if( subY > 0 && !isUp )
		{
			refUpMoveEnableParticleList.ForEach( (obj) => obj.Play() );
			refDownMoveEnableParticleList.ForEach( (obj) => obj.Stop() );
			isUp = true;
			isDown = false;
		}
		else if( subY < 0 && !isDown )
		{
			refDownMoveEnableParticleList.ForEach( (obj) => obj.Play() );
			refUpMoveEnableParticleList.ForEach( (obj) => obj.Stop() );
			isDown = true;
			isUp = false;
		}
		
		if( subY == 0.0f )
		{
			refUpMoveEnableParticleList.ForEach( (obj) => obj.Stop() );
			refDownMoveEnableParticleList.ForEach( (obj) => obj.Stop() );
			isDown = false;
			isUp = false;
		}
		
		oldPosition = position;
	}
}
