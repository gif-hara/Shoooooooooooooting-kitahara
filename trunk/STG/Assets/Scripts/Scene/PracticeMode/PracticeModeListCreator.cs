/*===========================================================================*/
/*
*     * FileName    : PracticeModeListCreator.cs
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
public class PracticeModeListCreator : MonoBehaviour
{
	[SerializeField]
	private CommandManager refCommandManager;

	[SerializeField]
	private GameObject prefabElement;

	[SerializeField]
	private Vector3 origin;
	
	[SerializeField]
	private float interval;

	public const string CreatedMessage = "OnCreatedPracticeStageElement";

	void Start ()
	{
		var index = (int)GameStatusInterfacer.Difficulty;
		var stageClearList = SaveData.Progresses.Instance.StageClearFrag[index];
		for( int i=0; i<5; i++ )
		{
			if( !stageClearList[i] )	break;

			var element = transform.InstantiateAsChild( transform, prefabElement );
			element.transform.localPosition = origin + Vector3.down * (interval * i);
			element.BroadcastMessage( CreatedMessage, i );
			refCommandManager.AddInputEvent( element.GetComponent<CommandEventHolder>().InputEvent );
		}

		refCommandManager.SetCursorId( 0 );
	}
}
