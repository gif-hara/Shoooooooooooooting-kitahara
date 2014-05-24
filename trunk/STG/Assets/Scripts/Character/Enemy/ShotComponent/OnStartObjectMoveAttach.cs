/*===========================================================================*/
/*
*     * FileName    : OnStartObjectMoveAttach.cs
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
public class OnStartObjectMoveAttach : ObjectMoveAttach
{
	public override void Start ()
	{
		Attach();
	}
}
