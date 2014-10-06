/*===========================================================================*/
/*
*     * FileName    : PlaySESpecialPointMax.cs
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
public class PlaySESpecialPointMax : GameMonoBehaviour
{
	[SerializeField]
	private string label;

	private bool isPlay = false;

	void OnModifiedSpecialPoint( float value )
	{
		if( isPlay && !ReferenceManager.Instance.RefPlayerStatusManager.IsMaxSpecialPoint )
		{
			isPlay = false;
		}
		else if( !isPlay && ReferenceManager.Instance.RefPlayerStatusManager.IsMaxSpecialPoint )
		{
			ReferenceManager.Instance.refSoundManager.Play( label );
			isPlay = true;
		}
	}
}
