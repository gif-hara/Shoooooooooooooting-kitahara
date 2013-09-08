/*===========================================================================*/
/*
*     * FileName    : PlayerShotCollider.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class PlayerShotCollider : A_Collider
{
	public GameObject refParent;
	
	public int power;
	
	private bool isEnemyCollision = false;
	
	public override void Awake()
	{
		base.Awake();
		ReferenceManager.refCollisionManager.AddPlayerShotCollider( this );
	}
	
	public override void Update()
	{
		base.Update();
		UpdatePositionZ();
		if( refParent.transform.position.y >= 300.0f )
		{
			Destroy( refParent );
		}
	}

	public override void OnCollision (A_Collider target)
	{
		Destroy( refParent );
		isEnemyCollision = true;
	}
	public override EType Type
	{
		get
		{
			return EType.PlayerShot;
		}
	}
	
	public bool IsEnemyCollision
	{
		get
		{
			return isEnemyCollision;
		}
	}
}
