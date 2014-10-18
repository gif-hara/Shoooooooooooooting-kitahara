/*===========================================================================*/
/*
*     * FileName    : A_Shot.cs
*
*     * Description : 弾抽象クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public abstract class A_Shot : GameMonoBehaviour
{
	private const float DestroyDistance = 450.0f * 450.0f;
	
	public void Initialize( float speed, Transform position, Transform angle, float fixedAngle )
	{
		if( ReferenceManager != null )
		{
			transform.parent = Parent;
		}
		PositionX = position.position.x;
		PositionY = position.position.y;
		LocalPositionZ = 0.0f;
				
		angle.localRotation *= Quaternion.AngleAxis( fixedAngle, Vector3.forward );
		var vector = angle.up;
		vector.z = 0.0f;
		SetAngle( vector );
		angle.localRotation *= Quaternion.AngleAxis( -fixedAngle, Vector3.forward );
		
		AutoMove autoMove = gameObject.AddComponent<AutoMove>();
		autoMove.speed = speed;
		autoMove.velocity = vector.normalized;
	}
	private void SetAngle( Vector3 euler )
	{
		transform.localRotation = Quaternion.LookRotation( euler, Vector3.back );
		transform.localRotation *= Quaternion.AngleAxis( 90.0f, Vector3.right );
	}
	protected void Destroy()
	{
//		float distance = 450.0f;
//		if( Vector3.Distance( Vector3.zero, Trans.position ) >= distance )
//		{
//			Destroy( gameObject );
//		}
		
//		float distance = 450.0f;
//		
//		if( Trans.position.sqrMagnitude >= (distance * distance) )
//		{
//			Destroy( gameObject );
//		}

//		var pos = Trans.position;
//		float rate = 1.2f;
//		float width = 400.0f * rate;
//		float height = 300.0f * rate;
//		if( pos.x > width || pos.x < -width ||
//			pos.y > height || pos.y < -height )
//		{
//			Destroy( gameObject );
//		}

	}
	
	protected abstract Transform Parent
	{
		get;
	}
}
