﻿/*===========================================================================*/
/*
*     * FileName    : ObjectPool.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// オブジェクトプールクラス.
/// </summary>
public class ObjectPool : MonoBehaviour
{
	private static ObjectPool instance;

	public static ObjectPool Instance
	{
		get
		{
			if( instance == null )
			{
				instance = FindObjectOfType<ObjectPool>();

				if( instance == null )
				{
					instance = new GameObject( "ObjectPool" ).AddComponent<ObjectPool>();
					DontDestroyOnLoad( instance.gameObject );
				}
			}

			return instance;
		}
	}

	void Awake()
	{
		if( instance == null )
		{
			instance = this;
		}
	}

	private Dictionary<int, Stack<GameObject>> pooledGameObjects = new Dictionary<int, Stack<GameObject>>();

	public GameObject GetGameObject( GameObject prefab, Vector3 position, Quaternion rotation )
	{
		int key = prefab.GetInstanceID();

		if( !pooledGameObjects.ContainsKey( key ) )
		{
			pooledGameObjects.Add( key, new Stack<GameObject>() );
		}

		var gameObjects = pooledGameObjects[key];
		GameObject go = null;

		if( gameObjects.Count <= 0 )
		{
			go = Instantiate( prefab, position, rotation ) as GameObject;
			go.AddComponent<PoolEntity>().Initialize( key );
			PoolableComponentsAction( go, (poolable) => poolable.OnAwakeByPool( false ) );
		}
		else
		{
			go = gameObjects.Pop();
			if( go.activeInHierarchy )
			{
				Debug.LogError( "go is already active. go = " + go.name );
			}
			go.transform.position = position;
			go.transform.rotation = rotation;
			go.SetActive( true );
			PoolableComponentsAction( go, (poolable) => poolable.OnAwakeByPool( true ) );
		}
		return go;
	}

	public GameObject GetGameObject( GameObject prefab )
	{
		return GetGameObject( prefab, prefab.transform.position, prefab.transform.rotation );
	}

	public void ReleaseGameObject( GameObject go )
	{
		if( !go.activeInHierarchy )
		{
			return;
		}

		PoolableComponentsAction( go, (poolable) => poolable.OnReleaseByPool() );
		pooledGameObjects[go.GetComponent<PoolEntity>().Key].Push( go );
		go.SetActive( false );
		go.transform.parent = transform;
	}

	private void PoolableComponentsAction( GameObject go, System.Action<I_Poolable> func )
	{
		var poolableComponents = go.GetComponentsInChildren( typeof( I_Poolable ) );
		if( poolableComponents == null )
		{
			return;
		}

		for( int i=0,imax=poolableComponents.Length; i<imax; i++ )
		{
			func( poolableComponents[i] as I_Poolable );
		}
	}
}
