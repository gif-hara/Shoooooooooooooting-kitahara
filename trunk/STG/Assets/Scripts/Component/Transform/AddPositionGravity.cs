/*===========================================================================*/
/*
*     * FileName    : AddPositionGravity.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 指定した重力によって座標を移動するコンポーネント.
/// </summary>
public class AddPositionGravity : GameMonoBehaviour, I_Poolable
{
	[SerializeField]
	private Transform refTarget;

	[SerializeField]
	private Vector3 gravity;

	[SerializeField]
	private float power;

	[SerializeField]
	private float addPower;

	private float cachedPower;

	[ContextMenu( "Gravity Normalize" )]
	void GravityNormalize()
	{
		this.gravity = this.gravity.normalized;
	}

	public override void Update ()
	{
		base.Update ();

		var localPosition = this.refTarget.localPosition;
		this.refTarget.localPosition = new Vector3(
			localPosition.x + this.gravity.x * this.power,
			localPosition.y + this.gravity.y * this.power,
			localPosition.z + this.gravity.z * this.power
			);

		this.power += this.addPower;
	}

	public void OnAwakeByPool( bool used )
	{
		if( !used )
		{
			this.cachedPower = this.power;
		}
		else
		{
			this.power = this.cachedPower;
		}
	}

	public void OnReleaseByPool()
	{

	}

	public void Limit( float limit )
	{
		this.power = this.power > limit ? limit : this.power;
	}
}
