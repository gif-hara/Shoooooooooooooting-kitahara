/*===========================================================================*/
/*
*     * FileName    : ReplayModeFireShot.cs
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
public class ReplayModeFireShot : GameMonoBehaviour
{
	[SerializeField]
	private List<PlayerShotFire> refPlayerShotFire;

	public override void Start ()
	{
		base.Start ();
		enabled = GameStatusInterfacer.GameMode == GameDefine.GameModeType.Replay;
	}

	public override void Update ()
	{
		if( ReferenceManager.ReplayDataLoader.CanInputFireKey( ReferenceManager.FrameCountRecorder.CurrentFrameCount ) )
		{
			refPlayerShotFire.ForEach( p =>
			{
				p.Fire();
			});
		}
	}
}
