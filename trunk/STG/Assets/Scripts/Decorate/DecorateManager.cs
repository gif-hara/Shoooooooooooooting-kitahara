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


public class DecorateManager
{
	private List<A_Decorate> decorateList;
	
	public DecorateManager( Transform owner )
	{
		decorateList = new List<A_Decorate>();
		
		for( int i=0,imax=owner.childCount; i<imax; i++ )
		{
			var element = owner.GetChild( i ).GetComponent<A_Decorate>();
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
