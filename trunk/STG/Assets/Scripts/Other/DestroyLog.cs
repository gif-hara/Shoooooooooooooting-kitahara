/*===========================================================================*/
/*
*     * FileName    : DestroyLog.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class DestroyLog : MonoBehaviour
{
	void OnDestroy()
	{
		Debug.LogError( "Destroy " + gameObject.name );
	}
}
