/*===========================================================================*/
/*
*     * FileName    : A_SetTextMeshReplayFile.cs
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
public abstract class A_SetTextMeshReplayFile : MonoBehaviour
{
	[SerializeField]
	private string nullString;

	void OnCreatedReplayListElement( int id )
	{
		var textMesh = GetComponent<TextMesh>();

		var replayData = SaveLoad.LoadReplayData( id );
		if( replayData == null )
		{
			textMesh.text = nullString;
//				StringAsset.Format(
//				"ReplayFileName",
//				id.ToString( "00" ),
//				"----/--/--  --:--",
//				"--------",
//				"----",
//				"----------"
//				);
		}
		else
		{
			textMesh.text = GetInformation( replayData );
		}
	}

	protected abstract string GetInformation( ReplayData replayData );
}
