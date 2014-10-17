/*===========================================================================*/
/*
*     * FileName    : AutoFireShot.cs
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
public class AutoFireShot : MonoBehaviour
{
	[SerializeField]
	private int delay;

	[SerializeField]
	private List<PlayerShotFire> refShotFireList;

	void Update()
	{
		if( delay > 0 )
		{
			delay--;
			return;
		}

		refShotFireList.ForEach( s =>
		{
			s.Fire();
		});
	}

	void OnPlayerSelectMode()
	{
		enabled = true;
	}
}
