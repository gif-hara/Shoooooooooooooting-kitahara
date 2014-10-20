/*===========================================================================*/
/*
*     * FileName    : SetTextMeshReplayFileName.cs
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
public class SetTextMeshReplayFileName : MonoBehaviour
{
	void OnCreatedReplayListElement( int id )
	{
		var textMesh = GetComponent<TextMesh>();

		var replayData = SaveLoad.LoadReplayData( id );
		if( replayData == null )
		{
			textMesh.text = StringAsset.Format(
				"ReplayFileName",
				id.ToString( "00" ),
				"----/--/--  --:--",
				"--------",
				"----",
				"----------"
				);
		}
		else
		{
			var timeStamp = new System.DateTime( replayData.TimeStamp );
			textMesh.text = StringAsset.Format(
				"ReplayFileName",
				id.ToString( "00" ),
				timeStamp.ToString( "yyyy/MM/dd  HH:mm" ),
				StringAsset.Get( string.Format( "Player{0}_Name", replayData.PlayerId ) ),
				replayData.Difficulty.ToString(),
				GameDefine.StageTypeString( replayData.StageType ).PadRight( 10 )
				);
		}
	}
}
