/*===========================================================================*/
/*
*     * FileName    : BooleanConditioner.cs
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
public class BooleanConditioner : MonoBehaviour
{
	public bool Flag{ set; get; }

	void CatchCondition( ConditionHolder holder )
	{
		holder.IsSuccess = Flag;
	}
}
