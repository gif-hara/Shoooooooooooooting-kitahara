//================================================
/*!
    @file   PoolEntity.cs

    @brief  .

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PoolEntity : MonoBehaviour
{
	public bool IsUse{ get{ return isUse; } }
	private bool isUse = false;
	
	public const string UseMessage = "PoolUse";
	
	public const string UnuseMessage = "PoolUnuse";
	
	private string gameObjectName = "";
	
	public void Using()
	{
		isUse = true;
		gameObject.SetActive( true );
		gameObject.BroadcastMessage( UseMessage, SendMessageOptions.DontRequireReceiver );
		
		if( string.IsNullOrEmpty( gameObjectName ) )
		{
			gameObjectName = gameObject.name;
		}
		gameObject.name = gameObjectName + " - Reuse";
	}
	
	public void Unuse()
	{
		isUse = false;
		ObjectPool.Pool( this );
		gameObject.SetActive( false );
		gameObject.BroadcastMessage( UnuseMessage, SendMessageOptions.DontRequireReceiver );
		gameObject.name = gameObjectName + "- Pool";
	}
}
