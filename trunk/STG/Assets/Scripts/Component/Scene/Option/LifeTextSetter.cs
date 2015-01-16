/*===========================================================================*/
/*
*     * FileName    : LifeTextSetter.cs
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
public class LifeTextSetter : MonoBehaviour
{
	[SerializeField]
	private TextMesh refTextMesh;

	void Start()
	{
		OnModifiedLife();
	}
	void OnModifiedLife()
	{
		refTextMesh.text = OptionData.Settings.Life.ToString();
	}
}
