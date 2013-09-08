/*===========================================================================*/
/*
*     * FileName    : UIBarrier.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UIBarrier : GameMonoBehaviour
{
	public UIBar refBar;
	
	public TextureOffsetAnimation refOffsetAnimation;
	
	public float barSpeed;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		var player = ReferenceManager.refPlayer;
		refBar.Initialize( player.maxSpecialPoint, player.CurrentSpecialPoint );
	}

	// Update is called once per frame
	public override void LateUpdate()
	{
		base.LateUpdate();
		refBar.Current += ((float)ReferenceManager.refPlayer.CurrentSpecialPoint - refBar.Current) / barSpeed;
	}

}
