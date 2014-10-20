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
	[SerializeField]
	private TextMesh refTextMesh;

	[SerializeField]
	private int id;

	void Start ()
	{
		var replayData = SaveLoad.LoadReplayData( id );
		if( replayData == null )
		{
			refTextMesh.text = StringAsset.Format(
				"ReplayFileName",
				id.ToString( "00" ),
				"----/--/--  --:--",
				"----------",
				"--------"
				);
		}
		else
		{
			var timeStamp = new System.DateTime( replayData.TimeStamp );
			refTextMesh.text = StringAsset.Format(
				"ReplayFileName",
				id.ToString( "00" ),
				timeStamp.ToString( "yyyy/MM/dd  HH:mm" ),
				GameDefine.StageTypeString( replayData.StageType ).PadRight( 10 ),
				StringAsset.Get( string.Format( "Player{0}_Name", replayData.PlayerId ) )
				);
		}
	}
}
