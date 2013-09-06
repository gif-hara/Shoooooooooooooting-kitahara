/*===========================================================================*/
/*
*     * FileName    : PlayerShot.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class PlayerShot : A_Shot
{
	public void Initialize( float speed, Transform position, Transform angle )
	{
		base.Initialize( speed, position, angle, 0.0f );
	}
	
	protected override Transform Parent {
		get
		{
			return ReferenceManager.refPlayerShotLayer.transform;
		}
	}
}
