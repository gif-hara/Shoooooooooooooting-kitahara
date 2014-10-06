/*===========================================================================*/
/*
*     * FileName    : PlayParticleSpecialPointMaxLoop.cs
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
public class PlayParticleSpecialPointMaxLoop : GameMonoBehaviour
{
	[SerializeField]
	private List<ParticleSystem> refParticleList;

	void OnModifiedSpecialPoint( float value )
	{
		bool flag = value >= PlayerStatusManager.MaxSpecialPoint;
		refParticleList.ForEach( p =>
		{
			if( flag && !p.isPlaying )
			{
				p.Play( true );
			}
			p.loop = flag;
		});
	}

}
