/*===========================================================================*/
/*
*     * FileName    : PrePool.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 予めプールを行うコンポーネント.
/// </summary>
public class PrePoolCoroutine : MonoBehaviour
{
	[SerializeField]
	private int interval;

	[SerializeField]
	private GameObject refReceiver;

    [SerializeField]
    private List<PrePool.Data> database;

	// Use this for initialization
	IEnumerator Start ()
	{
		var time =  Time.realtimeSinceStartup;
		this.refReceiver.SendMessage( Progressor.RequestMessage, this.YieldCount );

		int currentInterval = 0;
        for( int i=0; i<this.database.Count; i++ )
        {
            var data = this.database[i];
            var poolObjects = new List<GameObject>( data.poolNumber );
            for( int j=0; j<data.poolNumber; j++ )
            {
				var obj = ObjectPool.Instance.GetGameObject( data.prefab );
				obj.SetActive( false );
                poolObjects.Add( obj );

				currentInterval++;
				if(currentInterval >= this.interval)
				{
					currentInterval = 0;
					this.refReceiver.SendMessage( Progressor.AdvanceMessage, 1 );
					yield return new WaitForEndOfFrame();
				}
            }
            for( int j=0; j<data.poolNumber; j++ )
            {
                ObjectPool.Instance.ReleaseGameObject( poolObjects[j] );

				currentInterval++;
				if(currentInterval >= this.interval)
				{
					currentInterval = 0;
					this.refReceiver.SendMessage( Progressor.AdvanceMessage, 1 );
					yield return new WaitForEndOfFrame();
				}
			}
        }

		Debug.Log( "Complete " + (Time.realtimeSinceStartup - time) );
	}

	public int YieldCount
	{
		get
		{
			int totalPoolNumber = 0;
			database.ForEach( d =>
			{
				totalPoolNumber += d.poolNumber;
			});

			return totalPoolNumber / (this.interval / 2);
		}
	}
}
