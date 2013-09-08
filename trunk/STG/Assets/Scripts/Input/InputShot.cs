/*===========================================================================*/
/*
*     * FileName    : InputShot.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class InputShot : A_InputAction
{
	public GameObject prefabShot;
	
	public Transform refInstancePosition;
	
	public Transform refShotAngle;
	
	public float speed;
	
	public int interval;
	
	private int timer;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		decorateManager = new DecorateManager<A_InputAction>( this );
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		int benchMarkId = ScriptProfiler.Begin( this );
		
		if( Input.GetKey( KeyCode.Z ) && timer >= interval )
		{
			decorateManager.Decorate();
			timer = 0;
			GameObject shot = InstantiateAsChild( ReferenceManager.refPlayerShotLayer, prefabShot );
			shot.AddComponent<PlayerShot>().Initialize( speed, refInstancePosition, refShotAngle );
		}
		timer++;
		
		ScriptProfiler.End( this, benchMarkId );
	}

}
