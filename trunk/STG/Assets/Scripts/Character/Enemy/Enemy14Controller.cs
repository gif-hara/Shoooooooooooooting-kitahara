/*===========================================================================*/
/*
*     * FileName    : Enemy14Controller.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Enemy14Controller : GameMonoBehaviour
{
	private System.Action stateFunc = null;
	
	private EnemyController refController;
	
	public override void Awake()
	{
		stateFunc = State0;
		refController = GetComponent<EnemyController>();
		refController.updateFunc += UpdateState;
	}
	
	private void UpdateState()
	{
		stateFunc();
	}
	
	private void State0()
	{
		Debug.Log( "0" );
		
		if( refController.Hp <= 50000 )
		{
			stateFunc = State1;
		}
	}
	
	private void State1()
	{
		Debug.Log( "1" );
	}
}
