/*===========================================================================*/
/*
*     * FileName    : SetTextMeshReplayFileDate.cs
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
public class SetTextMeshReplayFileDate : A_SetTextMeshReplayFile
{
//		var textMesh = GetComponent<TextMesh>();
//
//		var replayData = SaveLoad.LoadReplayData( id );
//		if( replayData == null )
//		{
//			textMesh.text = nullString;
//		}
//		else
//		{
//			var timeStamp = new System.DateTime( replayData.TimeStamp );
//			textMesh.text = StringAsset.Format(
//				"ReplayFileName",
//				id.ToString( "00" ),
//				timeStamp.ToString( "yyyy/MM/dd  HH:mm" ),
//				StringAsset.Get( string.Format( "Player{0}_Name", replayData.PlayerId ) ),
//				replayData.Difficulty.ToString(),
//				"-- " + GameDefine.StageTypeString( replayData.StageType ) + " --"
//				);
//		}

	protected override string GetInformation (ReplayData replayData)
	{
		return new System.DateTime( replayData.TimeStamp ).ToString( "yyyy/MM/dd  HH:mm" );
	}
}
