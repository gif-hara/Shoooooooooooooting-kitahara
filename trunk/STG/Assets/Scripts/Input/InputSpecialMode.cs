/*===========================================================================*/
/*
*     * FileName    : InputSpecialMode.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class InputSpecialMode : A_InputAction
{
	[SerializeField]
	private Player refPlayer;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		decorateManager = new DecorateManager( Trans );
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
			refPlayer.StartSpecialMode();
		}
	}
}
