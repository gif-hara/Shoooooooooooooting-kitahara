/*===========================================================================*/
/*
*     * FileName    : CustomMenuItem.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class CustomMenuItem : MonoBehaviour
{
	[MenuItem("STG/Debug Mode %#1")]
	static void SetDefineDebugMode()
	{
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "STG_DEBUG");
	}

	[MenuItem("STG/Release Mode %#2")]
	static void SetDefineReleaseMode()
	{
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "STG_RELEASE");
	}
}
