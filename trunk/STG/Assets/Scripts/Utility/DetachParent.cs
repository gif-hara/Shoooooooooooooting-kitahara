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
	// Use this for initialization
	public override void Awake()
	{
		base.Awake();
		Trans.parent = null;
	}
}
