﻿/*===========================================================================*/
/*
*     * FileName    : PlayParticleNeedSpecialPointFill.cs
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
public class PlayParticleNeedSpecialPointEarn : GameMonoBehaviour
{
	[SerializeField]
	private List<ParticleSystem> refParticleList;

	private bool isPlay = false;
	
	void OnModifiedSpecialPoint( float value )
	{
		if( isPlay && value < ReferenceManager.Instance.Player.PrefabSpecialModeContent.NeedPoint )
		{
			isPlay = false;
		}
		else if( !isPlay && value >= ReferenceManager.Instance.Player.PrefabSpecialModeContent.NeedPoint )
		{
			refParticleList.ForEach( p =>
			{
				p.Play( true );
			});
			isPlay = true;
		}
	}
}