//================================================
/*!
    @file   ActiveSetterFromReferenceNull.cs

    @brief  参照オブジェクトがNullになったら指定したオブジェクトのActiveフラグを設定するコンポーネント.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ActiveSetterFromReferenceNull : MonoBehaviourExtension
{
	/// <summary>
	/// Null監視するオブジェクト参照リスト.
	/// </summary>
	public Transform[] refNullTarget;
	
	/// <summary>
	/// Activeフラグを設定するオブジェクト参照リスト.
	/// </summary>
	public GameObject[] refActiveTarget;
	
	/// <summary>
	/// Activeにするか.
	/// </summary>
	public bool isActive;
	
	// Update is called once per frame
	public override void Update ()
	{
		bool isProc = true;
		for( int i=0,imax=refNullTarget.Length; i<imax; i++ )
		{
			if( refNullTarget[i] != null )
			{
				isProc = false;
			}
		}
		
		if( !isProc )	return;
		
		for( int j=0,jmax=refActiveTarget.Length; j<jmax; j++ )
		{
			refActiveTarget[j].SetActive( isActive );
		}
		enabled = false;
	}
}
