/*===========================================================================*/
/*
*     * FileName    : ObjectMoveChasePlayer.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ObjectMoveChasePlayer : A_ObjectMove
{
	private Quaternion initialRotation;
	
	private Transform rotationObject;
	
	private Transform refPlayer;
	
	private bool isDisableLookAtComponent = false;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		refPlayer = ReferenceManager.Instance.refPlayer.Trans;

		var newObj = new GameObject( "[ObjectMoveChasePlayer]RotationObject" );
		rotationObject = newObj.transform;
	}
	
	public override void LateUpdate()
	{
		base.LateUpdate();
		if( data.delayFrame > 0 )	return;
		
		if( data.isSyncRotation )
		{
			refTrans.rotation = rotationObject.rotation;
		}
	}
	void OnDestroy()
	{
		if( rotationObject != null )
		{
			Destroy( rotationObject.gameObject );
		}
	}
	protected override void InitMove()
	{
		initialRotation = refTrans.rotation;
		rotationObject.rotation = initialRotation;
	}
	protected override void UpdateMove()
	{
		DisableLookAtComponent();
		SyncPlayerPosition();
		
		UpdateRotation();
		UpdatePosition();
		
		OverDistanceDestroy();
	}
	/// <summary>
	/// プレイヤー座標との同期取り.
	/// </summary>
	private void SyncPlayerPosition()
	{
		var pos = refTrans.position;
		rotationObject.position = new Vector3( pos.x, pos.y, refPlayer.position.z );
	}
	/// <summary>
	/// LookAt系コンポーネントを無効化.
	/// </summary>
	private void DisableLookAtComponent()
	{
		if( data.isSyncRotation && !isDisableLookAtComponent )
		{
			isDisableLookAtComponent = true;
			
			var lookAtComponent = refTrans.GetComponent<PlayerLookAt>();
			if( lookAtComponent == null )	return;
			
			lookAtComponent.enabled = false;
		}
	}
	/// <summary>
	/// 回転量の更新.
	/// </summary>
	private void UpdateRotation()
	{
		if( currentDuration >= data.durationFrame )	return;
		
		var oldRotation = rotationObject.rotation;
		rotationObject.LookAt( refPlayer, Vector3.forward );
		rotationObject.rotation *= Quaternion.AngleAxis( -90.0f, Vector3.right );

		var lookAt = rotationObject.rotation;
		rotationObject.rotation = Quaternion.Lerp( oldRotation, lookAt, 0.1f );
	}
	/// <summary>
	/// 座標更新.
	/// </summary>
	private void UpdatePosition()
	{
		var velocity = -rotationObject.up;
		velocity.z = 0.0f;
		velocity.Normalize();
		refTrans.position += velocity * data.curve0.Evaluate( Duration ) * data.speed;
		currentDuration++;
	}
}
