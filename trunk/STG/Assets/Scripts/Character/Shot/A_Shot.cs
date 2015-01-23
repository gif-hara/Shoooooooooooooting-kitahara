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
	public void Initialize( float speed, Vector3 position, Transform angle, float fixedAngle )
	{
		if( ReferenceManager != null )
		{
			transform.parent = Parent;
		}

        cachedTransform = transform;
        cachedTransform.position = new Vector3( position.x, position.y, cachedTransform.position.z );
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
	
	protected abstract Transform Parent
	{
		get;
	}
}
