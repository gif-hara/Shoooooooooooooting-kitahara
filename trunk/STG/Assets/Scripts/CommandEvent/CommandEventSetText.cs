/*===========================================================================*/
/*
*     * FileName    : CommandEventSetText.cs
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
public class CommandEventSetText : MonoBehaviour
{
	[SerializeField]
	private List<TextMesh> refTextMeshList;

	[SerializeField]
	private string text;

	void OnCommandEvent()
	{
		refTextMeshList.ForEach( t =>
		{
			t.text = text;
		});
	}
}
