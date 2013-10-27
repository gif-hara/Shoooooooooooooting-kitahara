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
	
	public bool isParentDetach;
	
	public List<GameObject> prefabList;
	
	public Vector2 min;
	
	public Vector2 max;
	
	public int interval;
	
	public int createNum;
	
	private int currentInterval = 0;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		if( refParent == null )
		{
			refParent = transform;
		}
		
//		for( int i=0; i<interval; i++ )
//		{
//			Vector3 pos = new Vector3( Random.Range( min.x, max.x ), Random.Range( min.y, max.y ), 0.0f );
//			var obj = InstantiateAsChild( Trans, prefabList[Random.Range( 0, prefabList.Count)] ).transform;
//			obj.localPosition = pos;
//			obj.parent = refParent;
//			currentInterval = 0;
//			enabled = false;
//		}
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		if( currentInterval >= interval )
		{
			Vector3 pos = new Vector3( Random.Range( min.x, max.x ), Random.Range( min.y, max.y ), 0.0f );
			var obj = InstantiateAsChild( Trans, prefabList[Random.Range( 0, prefabList.Count)] ).transform;
			obj.localPosition = pos;
			
			if( isParentDetach )
			{
				obj.parent = null;
			}
			else
			{
				obj.parent = refParent;
			}
			currentInterval = 0;
			createNum--;
			if( createNum <= 0 )
			{
				enabled = false;
			}
			return;
		}
		
		currentInterval++;
	}
	
	void OnDrawGizmos()
	{
		if( !enabled )	return;
		
		var center = refParent == null ? Vector3.zero : refParent.position;
		
		// 左.
		Gizmos.DrawLine( new Vector3( center.x + min.x, center.y + min.y, 0.0f ), new Vector3( center.x + min.x, center.y + max.y, 0.0f ) );
		
		// 上.
		Gizmos.DrawLine( new Vector3( center.x + min.x, center.y + min.y, 0.0f ), new Vector3( center.x + max.x, center.y + min.y, 0.0f ) );
		
		// 右.
		Gizmos.DrawLine( new Vector3( center.x + max.x, center.y + min.y, 0.0f ), new Vector3( center.x + max.x, center.y + max.y, 0.0f ) );
		
		// 下.
		Gizmos.DrawLine( new Vector3( center.x + min.x, center.y + max.y, 0.0f ), new Vector3( center.x + max.x, center.y + max.y, 0.0f ) );
	}
}
