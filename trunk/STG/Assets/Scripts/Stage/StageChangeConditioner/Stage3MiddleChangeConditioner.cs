/*===========================================================================*/
/*
*     * FileName    : Stage3MiddleChangeConditioner.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class Stage3MiddleChangeConditioner : A_StageChangeConditioner
{
	public override bool Condition()
	{
		return !isBasicRoot;
	}
}
