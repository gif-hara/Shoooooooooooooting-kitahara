/*===========================================================================*/
/*
*     * FileName    : ChaseGameObject.cs
*
*     * Description : 指定したゲームオブジェクトに追従するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ChaseGameObject : GameMonoBehaviour
{
	/// <summary>
	/// 追従するオブジェクト参照.
	/// </summary>
	public Transform refChaseObject;
	
	/// <summary>
	/// 速度.
	/// </summary>
	public float speed;
	
	// Update is called once per frame
	void LateUpdate()
	{
		if( refChaseObject == null )	return;
		
		Trans.position = Vector3.Lerp( Trans.position, refChaseObject.position, speed );
	}
}
