/*===========================================================================*/
/*
*     * FileName    : RankingListCreator.cs
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
public class RankingListCreator : MonoBehaviour
{
	[SerializeField]
	private GameObject prefabElement;
	
	[SerializeField]
	private int offset;

	[SerializeField]
	private int interval;

	private List<GameObject> elementList = new List<GameObject>();
	
	void OnModifyRankingDataList( RankingDataList data )
	{
		elementList.ForEach( e => Destroy( e ) );
		for( int i=0; i<data.Data.Count; i++ )
		{
			var element = this.InstantiateAsChild( transform, prefabElement );
			element.GetComponent<RankingElementObserver>().Content = data.Data[i];
			element.transform.localPosition = new Vector3(
				element.transform.localPosition.x,
				offset + i * interval,
				element.transform.localPosition.z
				);
			elementList.Add( element );
		}
	}
}
