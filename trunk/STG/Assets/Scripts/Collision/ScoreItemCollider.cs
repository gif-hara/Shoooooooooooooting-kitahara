/*===========================================================================*/
/*
*     * FileName    : ScoreItemCollider.cs
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
public class ScoreItemCollider : A_Collider
{
	[SerializeField]
	private ScoreItemController refController;

	public override void Awake()
	{
		base.Awake();
		ReferenceManager.refCollisionManager.AddItemCollider( this );
	}

	public override void OnCollision (A_Collider target)
	{
		Destroy( refController.gameObject );
		refController.OnPlayerCollide();
	}

	public override EType Type
	{
		get
		{
			return EType.Item;
		}
	}
}
