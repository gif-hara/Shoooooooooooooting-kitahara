/*===========================================================================*/
/*
*     * FileName    : InputShot.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;


public class InputShot : MonoBehaviour
{
	[SerializeField]
	private List<PlayerShotFire> refPlayerShotFireList;

	// Update is called once per frame
	void Update()
	{
		if( !Input.GetKey( KeyCode.Z ) )	return;

		refPlayerShotFireList.ForEach( p => p.Fire() );
	}

	void OnPlayerSelectMode()
	{
		enabled = false;
	}
}
