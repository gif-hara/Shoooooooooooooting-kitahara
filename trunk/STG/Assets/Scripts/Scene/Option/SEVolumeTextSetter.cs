/*===========================================================================*/
/*
*     * FileName    : SEVolumeTextSetter.cs
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
public class SEVolumeTextSetter : MonoBehaviour
{
	[SerializeField]
	private TextMesh refTextMesh;

	void Start()
	{
		OnModifiedSEVolume();
	}
	void OnModifiedSEVolume()
	{
		refTextMesh.text = OptionData.Option.SEVolume.ToString( "0.0" );
	}
}
