/*===========================================================================*/
/*
*     * FileName    : Stage4MiddleChangeConditioner.cs
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
public class Stage4MiddleChangeConditioner : A_StageChangeConditioner
{
	public override bool Condition()
	{
		return !isBasicRoot;
	}
}
