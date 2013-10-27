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
	
	/// <summary>
	/// 状態0終了時に有効化するオブジェクト.
	/// </summary>
	[SerializeField]
	private GameObject state0EndEventObject;
	
	/// <summary>
	/// 状態0が終了するヒットポイント.
	/// </summary>
	[SerializeField]
	private int state0EndHitPoint;
	
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
		if( refController.Hp <= state0EndHitPoint )
		{
			
			state0EndEventObject.SetActive( true );
			stateFunc = State1;
		}
	}
	
	private void State1()
	{
	}
}
