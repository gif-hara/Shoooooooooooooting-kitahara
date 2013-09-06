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
		
	void Update()
	{
	}
	void OnDrawGizmos()
	{
		if( isIconDraw )
		{
			Gizmos.DrawIcon( initialPosition, string.Format( "Enemy{0}.tga", enemyId ), false );
		}
		
		// TimeLineによる線描画.
		Gizmos.color = Color.red;
		Vector3 fromPos = Trans.position;
		Gizmos.DrawLine(
			fromPos,
			fromPos + Vector3.right * ( StageManager.StageX / 2.0f )
			);
	}	
	
	public void Initialize( int enemyId, int timeLine )
	{
		base.Initialize( timeLine );
		this.enemyId = enemyId;
		SyncData();
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
