/*===========================================================================*/
/*
*     * FileName    : InputBarrier.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class InputBarrier : A_InputAction
{
	public Player refPlayer;
	
	public GameObject prefabBarrier;
	
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
		UpdateIsValid();
	}
	
	private void UpdateIsValid()
	{
		if( Input.GetKeyDown( KeyCode.X ) )
		{
			refPlayer.StartSpecialMode( prefabBarrier );
		}
//		else if( Input.GetKeyUp( KeyCode.X ) && isValid )
//		{
//			isValid = false;
//			Destroy( currentBarrier );
//			refPlayer.EndBarrier();
//		}
	}
}
