/*===========================================================================*/
/*
*     * FileName    : GameStatusRandomSeedSetter.cs
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
public class GameStatusRandomSeedSetter : MonoBehaviour
{
	void Start ()
	{
		GameStatusInterfacer.RandomSeed = Random.seed;
		Debug.Log( "GameStatusInterfacer.RandomSeed = " + GameStatusInterfacer.RandomSeed );
	}
}
