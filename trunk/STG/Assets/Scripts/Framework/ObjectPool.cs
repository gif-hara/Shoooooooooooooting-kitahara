/*===========================================================================*/
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

	private Dictionary<int, List<GameObject>> pooledGameObjects = new Dictionary<int, List<GameObject>>();

	public GameObject GetGameObject( GameObject prefab, Vector3 position, Quaternion rotation )
	{
		int key = prefab.GetInstanceID();

		if( !pooledGameObjects.ContainsKey( key ) )
		{
			pooledGameObjects.Add( key, new List<GameObject>() );
		}

		List<GameObject> gameObjects = pooledGameObjects[key];
		GameObject go = null;

		for( int i=0,imax=gameObjects.Count; i<imax; i++ )
		{
			if( gameObjects[i].activeInHierarchy )
			{
				continue;
			}

			go = gameObjects[i];
			go.transform.position = position;
			go.transform.rotation = rotation;
			go.SetActive( true );
			PoolableComponentsAction( go, (poolable) => poolable.OnReuse() );

			return go;
		}

		go = Instantiate( prefab, position, rotation ) as GameObject;
		gameObjects.Add( go );

		return go;
	}

	public void ReleaseGameObject( GameObject go )
	{
		PoolableComponentsAction( go, (poolable) => poolable.OnRelease() );
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

		for( int j=0,jmax=poolableComponents.Length; j<jmax; j++ )
		{
			func( poolableComponents[j] as I_Poolable );
		}
	}
}
