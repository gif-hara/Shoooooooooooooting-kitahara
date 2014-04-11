/*===========================================================================*/
/*
*     * FileName    : ItemCollider.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class ItemCollider : A_Collider
{
	[SerializeField]
	private float chasedRadius;

	[SerializeField]
	private A_ItemController refController;

	private System.Action collisionFunc;

	public override void Awake()
	{
		base.Awake();
		ReferenceManager.refCollisionManager.AddItemCollider( this );
		collisionFunc = FallCollision;
	}

	public override void OnCollision (A_Collider target)
	{
		collisionFunc();
	}

	public override EType Type
	{
		get
		{
			return EType.Item;
		}
	}

	private void FallCollision()
	{
		refController.StartChasePlayer();
		collisionFunc = ChaseCollision;
		radius = chasedRadius;
	}

	private void ChaseCollision()
	{
		Destroy( refController.gameObject );
		refController.OnPlayerCollide();
	}
}
