/*===========================================================================*/
/*
*     * FileName    : BGMVolumeTextSetter.cs
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
public class BGMVolumeTextSetter : MonoBehaviour
{
	[SerializeField]
	private TextMesh refTextMesh;

	void Start()
	{
		OnModifiedBGMVolume();
	}
	void OnModifiedBGMVolume()
	{
		refTextMesh.text = OptionData.Settings.BGMVolume.ToString( "0.0" );
	}
}
