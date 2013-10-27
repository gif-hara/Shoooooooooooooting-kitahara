/*===========================================================================*/
/*
*     * FileName    : PositionSetter.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PositionSetter : MonoBehaviour
{
	/// <summary>
	/// 座標を変更するトランスフォーム.
	/// </summary>
	[SerializeField]
	private Transform refTarget;
	
	/// <summary>
	/// 座標.
	/// </summary>
	[SerializeField]
	private Vector3 position;
	
	/// <summary>
	/// ディレイ.
	/// </summary>
	[SerializeField]
	private int delay;
	
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		if( delay <= 0 )
		{
			refTarget.localPosition = position;
			enabled = false;
		}
		
		delay--;
	}
}
