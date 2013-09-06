/*===========================================================================*/
/*
*     * FileName    : PrefabCreatorInterval.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PrefabCreatorInterval : GameMonoBehaviour
{
	public Transform refParent;
	
	public List<GameObject> prefabList;
	
	public Vector2 min;
	
	public Vector2 max;
	
	public int interval;
	
	private int currentInterval = 0;
	
	// Use this for initialization
	void Start()
	{
		if( refParent == null )
		{
			refParent = transform;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if( currentInterval >= interval )
		{
			Vector3 pos = new Vector3( Random.Range( min.x, max.x ), Random.Range( min.y, max.y ), 0.0f );
			var obj = InstantiateAsChild( Trans, prefabList[Random.Range( 0, prefabList.Count)] ).transform;
			obj.localPosition = pos;
			obj.parent = refParent;
			currentInterval = 0;
			return;
		}
		
		currentInterval++;
	}

}
