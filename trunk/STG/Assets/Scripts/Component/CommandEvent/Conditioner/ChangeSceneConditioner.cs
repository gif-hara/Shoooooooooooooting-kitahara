/*===========================================================================*/
/*
*     * FileName    : ChangeSceneConditioner.cs
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
public class ChangeSceneConditioner : MonoBehaviour
{
	void CatchCondition( ConditionHolder holder )
	{
		holder.IsSuccess = SceneManager.Instance.CanChange;
	}
}
