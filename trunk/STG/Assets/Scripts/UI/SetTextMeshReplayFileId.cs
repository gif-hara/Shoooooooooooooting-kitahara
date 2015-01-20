/*===========================================================================*/
/*
*     * FileName    : SetTextMeshReplayFileId.cs
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
public class SetTextMeshReplayFileId : MonoBehaviour
{
	void OnCreatedReplayListElement( int id )
	{
		GetComponent<TextMesh>().text = "No." + id.ToString( "00" );
	}
}
