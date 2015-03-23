/*===========================================================================*/
/*
*     * FileName    : PoolEntity.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// プールされるコンポーネント.
/// </summary>
public class PoolEntity : MonoBehaviour
{
	public int Key{ private set; get; }

	public void Initialize( int key )
	{
		this.Key = key;
	}
}
