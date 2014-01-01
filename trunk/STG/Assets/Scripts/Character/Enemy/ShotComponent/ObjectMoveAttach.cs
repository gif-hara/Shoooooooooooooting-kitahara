/*===========================================================================*/
/*
*     * FileName    : ObjectMoveAttach.cs
*
*     * Description : ObjectMove系コンポーネントをアタッチするコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// ObjectMove系コンポーネントをアタッチするコンポーネント.
/// </summary>
public class ObjectMoveAttach : GameMonoBehaviour, I_MuzzleEventActinable
{
	[SerializeField]
	private A_ObjectMove prefabObjectMove;

	[SerializeField]
	private Transform refTrans;

	/// <summary>
	/// 生成したプレハブ保持.
	/// </summary>
	private GameObject currentObject = null;

	/// <summary>
	/// 銃口がアクティブになった際のイベント.
	/// </summary>
	public void OnActiveMuzzle()
	{
		Attach();
	}
	/// <summary>
	/// 敵弾生成メッセージ.
	/// </summary>
	public void OnEnemyShotCreate()
	{
		Attach();
	}
	/// <summary>
	/// アタッチ処理.
	/// </summary>
	private void Attach()
	{
		currentObject = InstantiateAsChild( refTrans, prefabObjectMove.gameObject );
		var list = currentObject.GetComponents<A_ObjectMove>();
		System.Array.ForEach<A_ObjectMove>( list, a =>
		{
			a.refTrans = refTrans;
		});
	}
}
