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


public class InputShot : GameMonoBehaviour
{
	[SerializeField]
	private List<PlayerShotFire> refPlayerShotFireList;

	// Update is called once per frame
	public override void Update()
	{
		if( PauseManager.Instance.IsPause )	return;
		
		if( !Input.GetKey( KeyCode.Z ) )	return;

		refPlayerShotFireList.ForEach( p => p.Fire() );
	}

	void OnPlayerSelectMode()
	{
		enabled = false;
	}

	void OnReplayMode()
	{
		enabled = false;
	}

}
