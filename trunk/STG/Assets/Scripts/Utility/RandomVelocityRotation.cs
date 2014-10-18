/*===========================================================================*/
/*
*     * FileName    : RandomVelocityRotation.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 移動量付きで回転量をランダムで設定するコンポーネント.
/// </summary>
public class RandomVelocityRotation : MonoBehaviour
{
	[SerializeField]
	private Transform refTarget;

	[SerializeField]
	private float duration;

	[SerializeField]
	private float min;

	[SerializeField]
	private float max;

	[SerializeField]
	private AnimationCurve curve;

	private Quaternion targetAngle;

	private float initialAngle = 0.0f;

	private Quaternion fromAngle;

	private float t;

	void Start ()
	{
		initialAngle = refTarget.localRotation.eulerAngles.z;
		min += initialAngle;
		max += initialAngle;
		SetTargetAngle();
	}
	
	void Update ()
	{
		if( PauseManager.Instance.IsPause )	return;
		
		refTarget.localRotation = Quaternion.Lerp( fromAngle, targetAngle, curve.Evaluate( t ) );

		if( t > 1.0f ) 
		{
			SetTargetAngle();
			t = 0.0f;
		}


		t += 1.0f / duration;
	}

	private void SetTargetAngle()
	{
		fromAngle = refTarget.localRotation;
		float targetAngleZ = Random.Range( min, max );
		targetAngleZ = (targetAngleZ < 0.0f) ? targetAngleZ + 360.0f : targetAngleZ;
		targetAngleZ = (targetAngleZ > 360.0f) ? targetAngleZ - 360.0f : targetAngleZ;
		targetAngle = Quaternion.Euler( 0.0f, 0.0f, targetAngleZ );
	}
}
