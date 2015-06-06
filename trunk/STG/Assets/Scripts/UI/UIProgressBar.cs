/*===========================================================================*/
/*
*     * FileName    : UIProgressBar.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class UIProgressBar : MonoBehaviour
{
	[SerializeField]
	private UIBar refBar;
	
	void OnModifiedProgress( float normalize )
	{
		Debug.Log( "normalize = " + normalize );
		this.refBar.Current = normalize;
	}
}
