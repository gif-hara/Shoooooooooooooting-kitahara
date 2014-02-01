/*===========================================================================*/
/*
*     * FileName    :SkyboxSetter.cs
*
*     * Description : .
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
public class SkyboxSetter : MonoBehaviour
{
	[SerializeField]
	private Material refMaterial;

	void Start ()
	{
		RenderSettings.skybox = refMaterial;
	}
}
