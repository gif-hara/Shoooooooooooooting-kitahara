/*===========================================================================*/
/*
*     * FileName    : DecorateManager.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DecorateManager<T> where T : MonoBehaviour
{
	private List<A_Decorate<T>> decorateList;
	
	public DecorateManager( T owner )
	{
		decorateList = new List<A_Decorate<T>>();
		
		var trans = owner.transform;
		for( int i=0,imax=trans.childCount; i<imax; i++ )
		{
			var element = trans.GetChild( i ).GetComponent<A_Decorate<T>>();
			if( element != null )
			{
				decorateList.Add( element );
			}
		}
	}
	public void Decorate()
	{
		decorateList.ForEach( (obj) =>
		{
			obj.Decorate();
		});
	}
}
