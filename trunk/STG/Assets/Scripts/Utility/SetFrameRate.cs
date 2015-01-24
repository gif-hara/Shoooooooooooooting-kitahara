/*===========================================================================*/
/*
*     * FileName    : SetFrameRate.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class SetFrameRate : MonoBehaviour
{
	[SerializeField]
	private List<int> frameRateList;

	[SerializeField]
	private int id;

	public void AddId( int value )
	{
		id += value;
		id = id < 0 ? 0 : id;
		var max = frameRateList.Count - 1;
		id = id > max ? max : id;

		Application.targetFrameRate = frameRateList[id];
	}
}
