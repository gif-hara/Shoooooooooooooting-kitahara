/*===========================================================================*/
/*
*     * FileName    : TransformExtension.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class TransformExtension
{
	public delegate void VisitDelegate( Transform trans );
	
	public static void AllVisit( this Transform self, VisitDelegate action )
	{
		action( self );
		for( int i=0,imax=self.childCount; i<imax; i++ )
		{
			AllVisit( self.GetChild( i ), action );
		}
	}
}
