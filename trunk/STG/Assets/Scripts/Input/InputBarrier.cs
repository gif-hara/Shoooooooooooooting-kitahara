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
	
	private bool isValid = false;
	
	private GameObject currentBarrier;
	
	// Use this for initialization
	void Start()
	{
		decorateManager = new DecorateManager<A_InputAction>( this );
	}

	// Update is called once per frame
	void Update()
	{
		UpdateIsValid();
	}
	
	private void UpdateIsValid()
	{
		if( Input.GetKeyDown( KeyCode.X ) && !isValid && refPlayer.IsBarrierExecute )
		{
			isValid = true;
			currentBarrier = InstantiateAsChild( refPlayer.Trans, prefabBarrier );
			refPlayer.BarrierExecute();
		}
		else if( Input.GetKeyUp( KeyCode.X ) && isValid )
		{
			isValid = false;
			Destroy( currentBarrier );
			refPlayer.EndBarrier();
		}
		
		if( refPlayer.CurrentSpecialPoint <= 0 )
		{
			Destroy( currentBarrier );
		}
	}
}
