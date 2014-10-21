/*===========================================================================*/
/*
*     * FileName    : SetTextMeshStageId.cs
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
public class SetTextMeshStageId : MonoBehaviour
{
	void OnCreatedPracticeStageElement( int id )
	{
		var textMesh = GetComponent<TextMesh>();
		textMesh.text = string.Format( textMesh.text, (id + 1).ToString( "00" ) );
	}
}
