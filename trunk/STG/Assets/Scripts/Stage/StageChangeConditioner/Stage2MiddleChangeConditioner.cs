/*===========================================================================*/
/*
*     * FileName    : Stage2MiddleChangeConditioner.cs
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
public class Stage2MiddleChangeConditioner : A_StageChangeConditioner
{
	public override bool Condition()
	{
		return !isBasicRoot;
	}
}
