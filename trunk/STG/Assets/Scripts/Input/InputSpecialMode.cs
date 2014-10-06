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

	public A_SpecialModeContent SpecialModeContent{ get{ return prefabInSpecialModeContent.GetComponent<A_SpecialModeContent>(); } }
	[SerializeField]
	private GameObject prefabInSpecialModeContent;
	
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
			refPlayer.StartSpecialMode( prefabInSpecialModeContent );
		}
	}
}
