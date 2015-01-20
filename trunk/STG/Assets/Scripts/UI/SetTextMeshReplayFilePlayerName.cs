/*===========================================================================*/
/*
*     * FileName    : SetTextMeshReplayFilePlayerName.cs
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
public class SetTextMeshReplayFilePlayerName : A_SetTextMeshReplayFile
{
	protected override string GetInformation (ReplayData replayData)
	{
		return StringAsset.Get( string.Format( "Player{0}_Name", replayData.PlayerId ) );
	}
}
