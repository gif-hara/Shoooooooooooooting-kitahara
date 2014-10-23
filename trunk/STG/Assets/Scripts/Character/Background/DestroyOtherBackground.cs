/*===========================================================================*/
/*
*     * FileName    : DestroyOtherBackground.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

public class DestroyOtherBackground : MonoBehaviour
{

	// Use this for initialization
	void Awake ()
	{
		if (ReferenceManager.Instance == null)
		{
			return;
		}

		var backgroundTransform = ReferenceManager.Instance.BackgroundLayer.transform;
		for( int i=0; i<backgroundTransform.childCount; i++ )
		{
			Destroy( backgroundTransform.GetChild( i ).gameObject );
		}
	}
}
