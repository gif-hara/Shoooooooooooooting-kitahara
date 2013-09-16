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
	private InputShot refInputShot;
	
	public void Initialize( InputShot inputShot, float speed, Transform position, Transform angle )
	{
		base.Initialize( speed, position, angle, 0.0f );
		this.refInputShot = inputShot;
	}
	
	void OnDestroy()
	{
		refInputShot.Cool();
	}
	
	protected override Transform Parent {
		get
		{
			return ReferenceManager.refPlayerShotLayer.transform;
		}
	}
}
