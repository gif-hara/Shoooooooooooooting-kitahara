/*===========================================================================*/
/*
*     * FileName    :EnemyShotOtherCreatePrefab.cs
*
*     * Description : 敵弾発射時にプレハブを生成するコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 敵弾発射時にプレハブを生成するコンポーネント.
/// </summary>
public class EnemyShotOtherCreatePrefab : A_EnemyShotOtherAction
{
	/// <summary>
	/// プレハブ.
	/// </summary>
	public GameObject prefab;

	public GameObject target;

	public const string ExtensionMessage = "OtherCreatePrefabExtension";

	public override void OtherAction ()
	{
		var obj = Instantiate( prefab, transform.position, Quaternion.identity ) as GameObject;
		target = target ?? gameObject;
		target.SendMessage( ExtensionMessage, obj, SendMessageOptions.DontRequireReceiver );
	}
}
