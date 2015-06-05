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
public class ItemCollider : A_Collider, I_Poolable
{
	[SerializeField]
	private float chasedRadius;

	[SerializeField]
	private A_ItemController refController;

	private System.Action collisionFunc;

	private float cachedFallRadius;

	public void OnAwakeByPool( bool used )
	{
		if( !used )
		{
			this.cachedFallRadius = this.radius;
		}

        if(ReferenceManager.Instance != null)
        {
    		ReferenceManager.refCollisionManager.AddItemCollider( this );
        }
		this.collisionFunc = FallCollision;
		this.enabled = true;
		this.radius = this.cachedFallRadius;
	}

	public void OnReleaseByPool()
	{
        if(ReferenceManager.Instance != null)
        {
    		ReferenceManager.Instance.refCollisionManager.RemoveItemCollider( this );
        }
		this.enabled = false;
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
		if( refController.IsFirstMove )
		{
			return;
		}

		refController.StartChasePlayer();
		collisionFunc = ChaseCollision;
		radius = chasedRadius;
	}

	private void ChaseCollision()
	{
		ObjectPool.Instance.ReleaseGameObject( refController.gameObject );
		refController.OnPlayerCollide();
	}
}
