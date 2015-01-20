/*===========================================================================*/
/*
*     * FileName    : SetTextMeshReplayFileClearedStageType.cs
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
public class SetTextMeshReplayFileClearedStageType : A_SetTextMeshReplayFile
{
	protected override string GetInformation (ReplayData replayData)
	{
		return GameDefine.StageTypeString( replayData.StageType );
	}
}
