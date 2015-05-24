/*===========================================================================*/
/*
*     * FileName    : CommandEventChangeWindowStyle.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class CommandEventChangeWindowStyle : MonoBehaviour
{
	[SerializeField]
	private GameObject modifiedEventObject;
	
	void OnCommandEvent()
	{
		OptionData.Settings.ChangeWindowStyle();
		modifiedEventObject.BroadcastMessage( "OnModifiedWindowStyle" );
	}
}
