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
	}
	public float radius;
	
	public override void Update()
	{
		base.Update();
		var pos = cachedTransform.position;
		cachedTransform.position = new Vector3( pos.x, pos.y, 0.0f );
	}
	
	public abstract void OnCollision( A_Collider target );
	
	public abstract EType Type{ get; }
	
	protected void UpdatePositionZ()
	{
		PositionZ = GameDefine.ColliderLayer;
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = GizmosColor;
		Gizmos.DrawWireSphere( transform.position, radius );
	}
	
	private Color GizmosColor
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
