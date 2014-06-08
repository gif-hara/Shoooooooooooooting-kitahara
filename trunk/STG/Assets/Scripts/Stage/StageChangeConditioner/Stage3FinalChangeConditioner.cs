/*===========================================================================*/
/*
*     * FileName    : Stage3FinalChangeConditioner.cs
*
*     * Description : ステージ1のステージ切り替え条件処理.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Stage3FinalChangeConditioner : A_StageChangeConditioner
{
	public override bool Condition()
	{
		return !isBasicRoot;
	}
}
