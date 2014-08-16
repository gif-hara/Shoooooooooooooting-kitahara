/*===========================================================================*/
/*
*     * FileName    : GameMonoBehaviour.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class GameMonoBehaviour : MonoBehaviourExtension
{
	/// <summary>
	/// 参照管理者クラスを返す.
	/// </summary>
	/// <value>
	/// The reference manager.
	/// </value>
	public static ReferenceManager ReferenceManager
	{
		get
		{
			return ReferenceManager.Instance;
		}
	}
	public static GameManager GameManager
	{
		get
		{
			return ReferenceManager.refGameManager;
		}
	}

	public static PlayerStatusManager PlayerStatusManager
	{
		get
		{
			return ReferenceManager.RefPlayerStatusManager;
		}
	}
	public static ScoreManager ScoreManager
	{
		get
		{
			return ReferenceManager.refScoreManager;
		}
	}
	public static SoundManager SoundManager
	{
		get
		{
			return ReferenceManager.refSoundManager;
		}
	}
	/// <summary>
	/// ゲーム定義クラスを返す.
	/// </summary>
	/// <value>
	/// The game define.
	/// </value>
	public static GameDefine GameDefine
	{
		get
		{
			return GameDefine.Instance;
		}
	}
	/// <summary>
	/// 引数の親オブジェクトの子としてプレハブの生成.
	/// </summary>
	/// <returns>
	/// The as child.
	/// </returns>
	/// <param name='parent'>
	/// Parent.
	/// </param>
	/// <param name='prefab'>
	/// Prefab.
	/// </param>
	public static GameObject InstantiateAsChild( Transform parent, GameObject prefab )
	{
		return InstantiateAsChild( parent.gameObject, prefab );
	}
	/// <summary>
	/// 引数の親オブジェクトの子としてプレハブの生成.
	/// </summary>
	/// <returns>
	/// The as child.
	/// </returns>
	/// <param name='parent'>
	/// Parent.
	/// </param>
	/// <param name='prefab'>
	/// Prefab.
	/// </param>
	public static GameObject InstantiateAsChild( GameObject parent, GameObject prefab )
	{
//		GameObject obj = ObjectPool.Reuse( prefab.GetComponent<PoolEntity>() ).gameObject;
//		obj.transform.parent = parent.transform;
		GameObject obj = NGUITools.AddChild( parent, prefab );
		obj.transform.localScale = prefab.transform.localScale;
		obj.layer = prefab.layer;
		
		return obj;
	}
	
	/// <summary>
	/// ローカルX座標プロパティ.
	/// </summary>
	/// <value>
	/// The local position x.
	/// </value>
	public float LocalPositionX
	{
		set
		{
			Vector3 localPos = transform.localPosition;
			localPos.x = value;
			transform.localPosition = localPos;
		}
		get
		{
			return transform.localPosition.x;
		}
	}
	/// <summary>
	/// ローカルX座標プロパティ.
	/// </summary>
	/// <value>
	/// The local position y.
	/// </value>
	public float LocalPositionY
	{
		set
		{
			Vector3 localPos = transform.localPosition;
			localPos.y = value;
			transform.localPosition = localPos;
		}
		get
		{
			return transform.localPosition.y;
		}
	}
	/// <summary>
	/// ローカルX座標プロパティ.
	/// </summary>
	/// <value>
	/// The local position z.
	/// </value>
	public float LocalPositionZ
	{
		set
		{
			Vector3 localPos = transform.localPosition;
			localPos.z = value;
			transform.localPosition = localPos;
		}
		get
		{
			return transform.localPosition.z;
		}
	}
	/// <summary>
	/// ワールドX座標プロパティ.
	/// </summary>
	/// <value>
	/// The position x.
	/// </value>
	public float PositionX
	{
		set
		{
			Vector3 localPos = transform.position;
			localPos.x = value;
			transform.position = localPos;
		}
		get
		{
			return transform.localPosition.x;
		}
	}
	/// <summary>
	/// ワールドX座標プロパティ.
	/// </summary>
	/// <value>
	/// The position y.
	/// </value>
	public float PositionY
	{
		set
		{
			Vector3 localPos = transform.position;
			localPos.y = value;
			transform.position = localPos;
		}
		get
		{
			return transform.localPosition.y;
		}
	}
	/// <summary>
	/// ワールドX座標プロパティ.
	/// </summary>
	/// <value>
	/// The position z.
	/// </value>
	public float PositionZ
	{
		set
		{
			Vector3 localPos = transform.position;
			localPos.z = value;
			transform.position = localPos;
		}
		get
		{
			return transform.localPosition.z;
		}
	}
}
