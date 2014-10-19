/*===========================================================================*/
/*
*     * FileName    : UILife.cs
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
public class UILife : GameMonoBehaviour
{
	[SerializeField]
	private List<GameObject> prefabLifeList;

	[SerializeField]
	private Vector2 interval;

	private List<GameObject> currentLifeList = new List<GameObject>();

	private int playerId;

	void OnSpawnPlayer( int id )
	{
		playerId = id;
		Initialize();
	}

	void OnResurrection()
	{
		if( DebugManager.IsNotLifeDecrement )	return;

		if( currentLifeList.Count <= 0 )
		{
			return;
		}

		int index = currentLifeList.Count - 1;
		Destroy( currentLifeList[index] );
		currentLifeList.RemoveAt( index );
	}

	void OnExtend()
	{
		CreateLife( playerId );
	}

	void OnContinue()
	{
		Initialize();
	}

	void Initialize()
	{
		currentLifeList.ForEach( g =>
		{
			Destroy( g );
		});
		currentLifeList.Clear();
		
		for( int i=0; i<ReferenceManager.RefPlayerStatusManager.Life - 1; i++ )
		{
			CreateLife( playerId );
		}
	}

	private void CreateLife( int id )
	{
		var life = InstantiateAsChild( Trans, prefabLifeList[id] );
		life.transform.localPosition = interval * currentLifeList.Count;
		currentLifeList.Add( life );
	}
}
