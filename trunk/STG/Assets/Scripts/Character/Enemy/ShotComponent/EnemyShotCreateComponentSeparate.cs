/*===========================================================================*/
/*
*     * FileName    : EnemyShotCreateComponentSeparate.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public abstract class EnemyShotCreateComponentSeparate : EnemyShotCreateComponent
{
	/// <summary>
	/// 弾数の区切り.
	/// </summary>
	public int separate;
	
#if UNITY_EDITOR
	public int currentSeparate;
#endif
	
	protected float Current
	{
		get
		{
			float current = owner.TotalShotCount % separate;
			return current / (float)separate;
		}
	}
	
	public override void Tuning ()
	{
		base.Tuning ();
#if UNITY_EDITOR
		currentSeparate = owner.TotalShotCount % separate;
#endif
	}
}
