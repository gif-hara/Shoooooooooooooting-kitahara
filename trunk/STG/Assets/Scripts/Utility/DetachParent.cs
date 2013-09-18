/*===========================================================================*/
/*
*     * FileName    : DetachParent.cs
*
*     * Description : 親子関係を切り離すコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DetachParent : GameMonoBehaviour
{
	public int delay;
	
	// Use this for initialization
	public override void Awake()
	{
		base.Awake();
		if( delay <= 0 )
		{
			Trans.parent = null;
		}
		else
		{
			FrameRateUtility.StartCoroutine( delay, () => Trans.parent = null );
		}
	}
}
