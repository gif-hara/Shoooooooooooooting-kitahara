/*===========================================================================*/
/*
*     * FileName    : Stage1ChangeConditioner.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Stage1ChangeConditioner : A_StageChangeConditioner
{
	/// <summary>
	/// 通常ルートか？.
	/// </summary>
	[SerializeField]
	private bool isBasicRoot;
	
	public override bool Condition()
	{
		return !isBasicRoot;
	}
}
