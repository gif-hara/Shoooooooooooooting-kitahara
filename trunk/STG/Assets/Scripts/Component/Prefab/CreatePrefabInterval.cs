/*===========================================================================*/
/*
*     * FileName    : CreatePrefabInterval.cs
*
*     * Description : 一定間隔でプレハブを生成するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CreatePrefabInterval : GameMonoBehaviour
{
	/// <summary>
	/// 親オブジェクト参照.
	/// </summary>
	[SerializeField]
	private Transform refParent;
	
	/// <summary>
	/// 生成した時に親を外すか.
	/// </summary>
	[SerializeField]
	private bool isParentDetach;
	
	/// <summary>
	/// 生成するプレハブ.
	/// </summary>
	[SerializeField]
	private List<GameObject> prefabList;
	
	/// <summary>
	/// 生成最低値.
	/// </summary>
	[SerializeField]
	public Vector2 min;
	
	/// <summary>
	/// 生成最大値.
	/// </summary>
	[SerializeField]
	public Vector2 max;
	
	/// <summary>
	/// 生成間隔.
	/// </summary>
	[SerializeField]
	public int interval;
	
	/// <summary>
	/// 生成する回数.
	/// </summary>
	[SerializeField]
	public int createNum;

	[SerializeField]
	private GameDefine.CreateType createType = GameDefine.CreateType.Instantiate;
	
	private int currentInterval = 0;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		if( refParent == null )
		{
			refParent = transform;
		}
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();

		if( PauseManager.Instance.IsPause )	return;
		
		if( currentInterval >= interval )
		{
			Vector3 pos = new Vector3( Random.Range( min.x, max.x ), Random.Range( min.y, max.y ), 0.0f );

			Transform obj = null;

			if( this.createType == GameDefine.CreateType.Instantiate )
			{
				obj = InstantiateAsChild( Trans, prefabList[Random.Range( 0, prefabList.Count)] ).transform;
			}
			else
			{
				obj = ObjectPool.Instance.GetGameObject( prefabList[Random.Range( 0, prefabList.Count)] ).transform;
				obj.parent = Trans;
			}

			obj.localPosition = pos;
			
			if( isParentDetach )
			{
				obj.parent = null;
			}
			else
			{
				obj.parent = refParent;
			}
			currentInterval = 0;
			createNum--;
			if( createNum <= 0 )
			{
				enabled = false;
			}
			return;
		}
		
		currentInterval++;
	}
	
	void OnDrawGizmosSelected()
	{
		if( !enabled )	return;
		
		var center = refParent == null ? Vector3.zero : refParent.position;
		
		// 左.
		Gizmos.DrawLine( new Vector3( center.x + min.x, center.y + min.y, 0.0f ), new Vector3( center.x + min.x, center.y + max.y, 0.0f ) );
		
		// 上.
		Gizmos.DrawLine( new Vector3( center.x + min.x, center.y + min.y, 0.0f ), new Vector3( center.x + max.x, center.y + min.y, 0.0f ) );
		
		// 右.
		Gizmos.DrawLine( new Vector3( center.x + max.x, center.y + min.y, 0.0f ), new Vector3( center.x + max.x, center.y + max.y, 0.0f ) );
		
		// 下.
		Gizmos.DrawLine( new Vector3( center.x + min.x, center.y + max.y, 0.0f ), new Vector3( center.x + max.x, center.y + max.y, 0.0f ) );
	}
}
