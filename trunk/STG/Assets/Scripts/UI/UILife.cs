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

	void OnSpawnPlayer( int id )
	{
		currentLifeList.ForEach( g =>
		{
			Destroy( g );
		});
		currentLifeList.Clear();

		for( int i=0; i<ReferenceManager.RefPlayerStatusManager.Life - 1; i++ )
		{
			CreateLife( id );
		}
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

	private void CreateLife( int id )
	{
		var life = InstantiateAsChild( Trans, prefabLifeList[id] );
		life.transform.localPosition = interval * currentLifeList.Count;
		currentLifeList.Add( life );
	}
}
