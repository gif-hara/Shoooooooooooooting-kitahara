/*===========================================================================*/
/*
*     * FileName    : DestroyOnNullReference.cs
*
*     * Description : 参照オブジェクトがNullになったら死亡するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DestroyOnNullReference : MonoBehaviour
{
	public GameObject refDestroyObject;
	
	public GameObject refTarget;
	
	// Update is called once per frame
	void Update()
	{
		if( refTarget == null )
		{
			Destroy( refDestroyObject );
		}
	}
}
