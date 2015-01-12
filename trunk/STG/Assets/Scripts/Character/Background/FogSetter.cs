/*===========================================================================*/
/*
*     * FileName    : FogSetter.cs
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
public class FogSetter : MonoBehaviour
{
	[SerializeField]
	private bool apply;

	[SerializeField]
	private Color color;

	[SerializeField]
	private float density;

	void Start ()
	{
		RenderSettings.fog = apply;
		RenderSettings.fogColor = color;
		RenderSettings.fogDensity = density;
	}
}
