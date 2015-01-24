/*===========================================================================*/
/*
*     * FileName    : CommandEventSetFrameRateSetId.cs
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
public class CommandEventSetFrameRateSetId : MonoBehaviour
{
	[SerializeField]
	private SetFrameRate refTarget;

	[SerializeField]
	private int value;

	void OnCommandEvent()
	{
		refTarget.AddId( value );
	}
}
