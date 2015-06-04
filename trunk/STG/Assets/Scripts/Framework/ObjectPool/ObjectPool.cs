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

	/// <summary>
	/// プールされたエンティティ.
	/// </summary>
	private Dictionary<int, Stack<PoolEntity>> pooledEntities = new Dictionary<int, Stack<PoolEntity>>();

	/// <summary>
	/// プールエンティティ.
	/// </summary>
	private List<PoolEntity> poolEntities = new List<PoolEntity>();

	void OnChangeScene( string sceneName )
	{
		for( int i=0,imax=this.poolEntities.Count; i<imax; i++ )
		{
			var entity = this.poolEntities[i];
			if( entity.IsPooled )
			{
				continue;
			}
			Debug.Log( "pool TargetName = " + entity.TargetName, entity );
			Debug.Log( "pool gameObject = " + entity.gameObject, entity );
			this.ReleaseGameObject( entity.gameObject );
		}
	}

	public GameObject GetGameObject( GameObject prefab, Vector3 position, Quaternion rotation )
	{
		int key = prefab.GetInstanceID();

		if( !pooledEntities.ContainsKey( key ) )
		{
			pooledEntities.Add( key, new Stack<PoolEntity>() );
		}

		var entities = pooledEntities[key];
		GameObject go = null;
		PoolEntity entity = null;

		if( entities.Count <= 0 )
		{
			go = Instantiate( prefab, position, rotation ) as GameObject;
			entity = go.AddComponent( typeof( PoolEntity ) ) as PoolEntity;
			entity.Initialize( key );
			this.poolEntities.Add( entity );
			PoolableComponentsAction( go, (poolable) => poolable.OnAwakeByPool( false ) );
		}
		else
		{
			entity = entities.Pop();
			entity.Reuse();
			go = entity.gameObject;
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
		var entity = go.GetComponent( typeof( PoolEntity ) ) as PoolEntity;
		if( !entity )
		{
			Debug.LogException( new System.InvalidCastException( "PoolEntity did not exist. go = " + go.name ) );
			return;
		}
		if( entity.IsPooled )
		{
			return;
		}

		PoolableComponentsAction( go, (poolable) => poolable.OnReleaseByPool() );
		entity.Pool();
		pooledEntities[entity.Key].Push( entity );
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
