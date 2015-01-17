/*===========================================================================*/
/*
*     * FileName    : SetSeed.cs
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
public class SetSeed : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
	{
		var playerPosition = ReferenceManager.Instance.Player.Trans.position;
		Random.seed = (int)playerPosition.x + (int)playerPosition.y;
		Debug.Log( "seed = " + Random.seed );
	}
}
