/*===========================================================================*/
/*
*     * FileName    : SingletonSystemCreator.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class SingletonSystemCreator : MonoBehaviour
{
	[SerializeField]
	private GameObject prefabDontDestroyObject;

	void Awake()
	{
		var obj = Instantiate( prefabDontDestroyObject );
		DontDestroyOnLoad( obj );
	}
}
