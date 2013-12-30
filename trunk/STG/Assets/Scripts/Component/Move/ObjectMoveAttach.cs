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
	/// 銃口がアクティブになった際のイベント.
	/// </summary>
	public void OnActiveMuzzle()
	{
		Attach();
	}
	/// <summary>
	/// アタッチ処理.
	/// </summary>
	private void Attach()
	{
		var objectMove = InstantiateAsChild( refTrans, prefabObjectMove.gameObject ).GetComponent<A_ObjectMove>();
		objectMove.refTrans = refTrans;
	}
}
