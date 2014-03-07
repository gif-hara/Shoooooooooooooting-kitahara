/*===========================================================================*/
/*
*     * FileName    :EnemyShotOtherCreatePrefabObjectMoveTweenTargetRandomSetter.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵弾生成時に生成したプレハブにObjectTweenのtargetPositionをランダムに設定するコンポーネント.
/// </summary>
public class EnemyShotOtherCreatePrefabObjectMoveTweenTargetRandomSetter : MonoBehaviour
{
	[SerializeField]
	private Vector2 size;

	[SerializeField]
	private float offsetZ;

	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube( transform.position, size );
	}

	public void OtherCreatePrefabExtension( GameObject obj )
	{
		Vector3 pos = transform.position;
		pos.x += Random.Range( -size.x / 2.0f, size.x / 2.0f );
		pos.y += Random.Range( -size.y / 2.0f, size.y / 2.0f );
		pos.z = offsetZ;
		obj.GetComponent<ObjectMoveTween>().data.targetPosition = pos;
	}
}
