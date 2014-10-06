/*===========================================================================*/
/*
*     * FileName    : PlayParticleNeedSpecialPointMaxSingle.cs
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
public class PlayParticleSpecialPointMaxSingle : GameMonoBehaviour
{
	[SerializeField]
	private List<ParticleSystem> refParticleList;

	private bool isPlay = false;
	
	void OnModifiedSpecialPoint( float value )
	{
		if( isPlay && !ReferenceManager.Instance.RefPlayerStatusManager.IsMaxSpecialPoint )
		{
			isPlay = false;
		}
		else if( !isPlay && ReferenceManager.Instance.RefPlayerStatusManager.IsMaxSpecialPoint )
		{
			refParticleList.ForEach( p =>
			{
				p.Play( true );
			});
			isPlay = true;
		}
	}
}
