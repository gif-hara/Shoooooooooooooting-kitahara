/*===========================================================================*/
/*
*     * FileName    : PrePool.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 予めプールを行うコンポーネント.
/// </summary>
public class PrePool : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public GameObject prefab;

        public int poolNumber;
    }

    [SerializeField]
    private List<Data> database;

	// Use this for initialization
	void Start ()
	{
        for( int i=0; i<this.database.Count; i++ )
        {
            var data = this.database[i];
            var poolObjects = new List<GameObject>( data.poolNumber );
            for( int j=0; j<data.poolNumber; j++ )
            {
                poolObjects.Add( ObjectPool.Instance.GetGameObject( data.prefab ) );
            }
            for( int j=0; j<data.poolNumber; j++ )
            {
                ObjectPool.Instance.ReleaseGameObject( poolObjects[j] );
            }
        }
	}
}
