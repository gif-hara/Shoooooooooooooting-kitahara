//================================================
/*!
    @file   ObjectTableBase.cs

    @brief  オブジェクトプールコンポーネント.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ObjectPool : MonoBehaviour
{
	/// <summary>
	/// 実体.
	/// </summary>
	private static ObjectPool Instance
	{
		get
		{
			if( instance == null )
			{
				GameObject obj = new GameObject( "ObjectPool" );
				instance = obj.AddComponent<ObjectPool>();
			}
			
			return instance;
		}
	}
	private static ObjectPool instance = null;
	
	private List<List<PoolEntity>> poolList = new List<List<PoolEntity>>();
	
	private Dictionary<PoolEntity, int> poolListDictionary = new Dictionary<PoolEntity, int>();
	
	public static PoolEntity Reuse( PoolEntity inPoolOriginal, Vector3 position, Quaternion rotation )
	{
		int value = -1;
		PoolEntity obj = null;
		if( !Instance.poolListDictionary.TryGetValue( inPoolOriginal, out value ) )
		{
			value = Instance.poolList.Count;
			Instance.poolListDictionary.Add( inPoolOriginal, value );
			Instance.poolList.Add( new List<PoolEntity>() );
			obj = Instantiate( inPoolOriginal, position, rotation ) as PoolEntity;
			Instance.poolList[value].Add( obj );
		}
		else
		{
			bool isUse = false;
			foreach( var p in Instance.poolList[value] )
			{
				if( p.IsUse )	continue;
				
				obj = p;
				isUse = true;
				break;
			}
			
			if( !isUse )
			{
				obj = Instantiate( inPoolOriginal, position, rotation ) as PoolEntity;
				Instance.poolList[value].Add( obj );
			}
		}
		
		obj.Using();
		
		return obj;
	}
	
	public static PoolEntity Reuse( PoolEntity inPoolOriginal )
	{
		return Reuse( inPoolOriginal, inPoolOriginal.transform.position, inPoolOriginal.transform.rotation );
	}
	
	public static void Pool( PoolEntity entity )
	{
		entity.transform.parent = Instance.transform;
	}
}
