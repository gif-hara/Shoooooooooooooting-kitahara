/*===========================================================================*/
/*
*     * FileName    : LimitPowerAddPositionGravity.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// AddPositionGravityのPowerに制限をかけるコンポーネント.
/// </summary>
[RequireComponent( typeof( AddPositionGravity ) )]
public class LimitPowerAddPositionGravity : MonoBehaviour
{
	[SerializeField]
	private float limit;

	[SerializeField]
	private AddPositionGravity refTarget;

	// Update is called once per frame
	void LateUpdate ()
	{
		this.refTarget.Limit( this.limit );
	}
}
