/*===========================================================================*/
/*
*     * FileName    : ReplayDataListCreator.cs
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
public class ReplayDataListCreator : MonoBehaviour
{
	[SerializeField]
	private CommandManager refCommandManager;

	[SerializeField]
	private GameObject prefabElement;

	[SerializeField]
	private Vector3 origin;

	[SerializeField]
	private float interval;

	public const string CreatedMessage = "OnCreatedReplayListElement";

	void Start ()
	{
		for( int i=0; i<ReplayData.Capacity; i++ )
		{
			var element = transform.InstantiateAsChild( transform, prefabElement );
			element.transform.localPosition = origin + Vector3.down * (interval * i);
			element.BroadcastMessage( CreatedMessage, i );
			refCommandManager.AddInputEvent( element.GetComponent<CommandEventHolder>().InputEvent );
		}

		refCommandManager.SetCursorId( 0 );
	}
}
