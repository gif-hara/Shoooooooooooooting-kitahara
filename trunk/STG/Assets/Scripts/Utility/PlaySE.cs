/*===========================================================================*/
/*
*     * FileName    : PlaySE.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlaySE : GameMonoBehaviour
{
	public string label;
	
	public int delay;
	
	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		if( delay <= 0 )
		{
			SoundManager.Instance.Play( label );
			enabled = false;
		}
		
		delay--;
	}
}
