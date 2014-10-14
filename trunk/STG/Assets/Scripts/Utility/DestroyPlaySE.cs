/*===========================================================================*/
/*
*     * FileName    : DestroyPlaySE.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DestroyPlaySE : GameMonoBehaviour
{
	public string label;
	
	private bool isApplicationQuit = false;
	
	void OnApplicationQuit()
	{
		isApplicationQuit = true;
	}
	
	void OnDestroy()
	{
		if( isApplicationQuit )	return;
		
		SoundManager.Instance.Play( label );
	}
}
