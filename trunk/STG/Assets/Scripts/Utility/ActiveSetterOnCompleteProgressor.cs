/*===========================================================================*/
/*
*     * FileName    : ActiveSetterOnCompleteProgressor.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class ActiveSetterOnCompleteProgressor : MonoBehaviour
{
	[SerializeField]
	private GameObject refTarget;

	[SerializeField]
	private bool isActive;

	void OnModifiedProgress( float normalize )
	{
		if( normalize < 1 )
		{
			return;
		}

		this.refTarget.SetActive( this.isActive );
	}
}
