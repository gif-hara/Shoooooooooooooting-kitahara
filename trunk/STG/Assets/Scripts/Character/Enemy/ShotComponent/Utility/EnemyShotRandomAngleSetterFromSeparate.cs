/*===========================================================================*/
/*
*     * FileName    : EnemyShotRandomAngleSetterFromSeparate.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class EnemyShotRandomAngleSetterFromSeparate : EnemyShotCreateComponentSeparate
{
	/// <summary>
	/// セパレートタイプ.
	/// </summary>
	public enum SeparateType : int
	{
		/// <summary>
		/// 一度だけランダム値を求める.
		/// </summary>
		OneCalc,
		
		/// <summary>
		/// 通常のセパレートタイプ.
		/// </summary>
		BasicSeparate,
	}
	
	public SeparateType separateType;
	
	public float origin;
	
	protected override void TuningFromSet ()
	{
		if( separateType == SeparateType.BasicSeparate )
		{
			float random = element.Evalute( (float)(owner.TotalShotCount % separate) / separate );
			random = Random.Range( -random, random );
			random = origin + random;
			owner.transform.localRotation = Quaternion.AngleAxis( random, Vector3.forward );
		}
		else
		{
			if( (owner.TotalShotCount) % separate == 0 )
			{
				float random = element.Evalute();
				random = Random.Range( -random, random );
				random = origin + random;
				owner.transform.localRotation = Quaternion.AngleAxis( random, Vector3.forward );
			}
		}
	}
	protected override void TuningFromAdd ()
	{
		if( separateType == SeparateType.BasicSeparate )
		{
			float random = element.Evalute( (float)(owner.TotalShotCount % separate) / separate );
			random = Random.Range( -random, random );
			owner.transform.localRotation *= Quaternion.AngleAxis( random, Vector3.forward );
		}
		else
		{
			if( (owner.TotalShotCount) % separate == 0 )
			{
				float random = element.Evalute();
				random = Random.Range( -random, random );
				owner.transform.localRotation *= Quaternion.AngleAxis( random, Vector3.forward );
			}
		}
	}
}
