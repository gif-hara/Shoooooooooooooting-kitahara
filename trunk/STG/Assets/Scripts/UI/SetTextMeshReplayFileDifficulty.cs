/*===========================================================================*/
/*
*     * FileName    : SetTextMeshReplayFileDifficulty.cs
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
public class SetTextMeshReplayFileDifficulty : A_SetTextMeshReplayFile
{
	protected override string GetInformation (ReplayData replayData)
	{
		return replayData.Difficulty.ToString();
	}
}
