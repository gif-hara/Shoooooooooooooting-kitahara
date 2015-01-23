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
	private PlayerShotFire refPlayerShotFire;
	
	public void Initialize( PlayerShotFire playerShotFire, float speed, Vector3 position, Transform angle )
	{
		base.Initialize( speed, position, angle, 0.0f );
		this.refPlayerShotFire = playerShotFire;
	}
	
	void OnDestroy()
	{
		refPlayerShotFire.Cool();
	}
	
	protected override Transform Parent {
		get
		{
			return ReferenceManager.refPlayerShotLayer.transform;
		}
	}
}
