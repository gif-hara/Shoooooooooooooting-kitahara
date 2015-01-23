/*===========================================================================*/
/*
*     * FileName    : A_Collider.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public abstract class A_Collider : GameMonoBehaviour
{
	public enum EType : int
	{
		Player,
		PlayerShot,
		Enemy,
		EnemyShot,
		Barrier,
		Item,
	}
	public float radius;
	
	public int delayUpdate = 0;
	
	public override void Update()
	{
		if( delayUpdate > 0 )
		{
            delayUpdate--;
            return;
        }

		base.Update();
		var pos = cachedTransform.position;
		cachedTransform.position = new Vector3( pos.x, pos.y, 0.0f );
	}

	public virtual void Hit( A_Collider target )
	{

	}

	public abstract void OnCollision( A_Collider target );
	
	public abstract EType Type{ get; }
	
	protected void UpdatePositionZ()
	{
		var pos = cachedTransform.position;
		cachedTransform.position = new Vector3( pos.x, pos.y, 0.0f );
	}
	
	void OnDrawGizmosSelected()
	{
		Gizmos.color = GizmosColor;
		Gizmos.DrawWireSphere( transform.position, radius );
	}
	
	protected Color GizmosColor
	{
		get
		{
			var result = Color.red;
			if( !enabled )	
			{
				result.r /= 2.0f;
			}
			
			return result;
		}
	}
}
