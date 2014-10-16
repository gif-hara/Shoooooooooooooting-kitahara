﻿/*===========================================================================*/
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

	private static bool isCreate = false;

	void Awake()
	{
		if( isCreate )	return;

		isCreate = true;
		var obj = Instantiate( prefabDontDestroyObject );
		DontDestroyOnLoad( obj );
	}
}
