/*===========================================================================*/
/*
*     * FileName    :EnemyShotOtherCreatePrefabObjectMoveTweenTargetSetter.cs
*
*     * Description : 敵弾生成時に生成したプレハブにObjectTweenのtargetPositionを設定するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵弾生成時に生成したプレハブにObjectTweenのtargetPositionを設定するコンポーネント.
/// </summary>
public class EnemyShotOtherCreatePrefabObjectMoveTweenTargetSetter : MonoBehaviour
{
	[SerializeField]
	private List<Transform> refTargetList;

	private int count = 0;

	public void OtherCreatePrefabExtension( GameObject obj )
	{
		int id = count % refTargetList.Count;
		count++;
		obj.GetComponent<ObjectMoveTween>().data.targetPosition = refTargetList[id].position;
	}
}
