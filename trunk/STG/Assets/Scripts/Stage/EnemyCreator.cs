/*===========================================================================*/
/*
*     * FileName    : EnemyCreator.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;


public class EnemyCreator : A_StageTimeLineActionable
{
	/// <summary>
	/// 敵ID.
	/// </summary>
	public int enemyId;
	
	/// <summary>
	/// 初期座標.
	/// </summary>
	public Vector3 initialPosition;
	
	/// <summary>
	/// 移動データリスト.
	/// </summary>
	public List<A_ObjectMove.Data> dataList;
	
	/// <summary>
	/// UnityEditor用のアイコン表示フラグ.
	/// </summary>
	public bool isIconDraw;
		
	public override void OnDrawGizmos()
	{
		if( isIconDraw )
		{
			Gizmos.DrawIcon( initialPosition, string.Format( "Enemy{0}.tga", enemyId ), false );
		}
		
		base.OnDrawGizmos();
	}	
	
	public void Initialize( int enemyId, int timeLine )
	{
		base.Initialize( timeLine );
		this.enemyId = enemyId;
		SyncData();
	}
	
	public void OffsetPosition( Vector3 offset )
	{
		var initPos = initialPosition;
		initialPosition = new Vector3( initPos.x + offset.x, initPos.y + offset.y, initPos.z + offset.z );
		foreach( var d in dataList )
		{
			initPos = d.targetPosition;
			d.targetPosition = new Vector3( initPos.x + offset.x, initPos.y + offset.y, initPos.z + offset.z );
		}
	}
	
	public override void Action()
	{
		var obj = InstantiateAsChild( ReferenceManager.refEnemyLayer, ReferenceManager.prefabEnemyList[enemyId] );
		obj.transform.position = initialPosition;
		
		var enemy = obj.GetComponent<EnemyController>();
		enemy.InitMoveDataList( dataList );
		
		Destroy( gameObject );
	}
	
	protected override string GameObjectName
	{
		get
		{
			return string.Format( "[{0}] Enemy{1}", timeLine, enemyId );
		}
	}
}
