/*===========================================================================*/
/*
*     * FileName    : ScoreItemController.cs
*
*     * Description : スコアアイテムコントローラコンポーネント.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// スコアアイテムコントローラコンポーネント.
/// </summary>
public class ScoreItemController : A_ItemController
{
	[SerializeField]
	private int id;

	public override void StartChasePlayer ()
	{

	}

	public override void OnPlayerCollide()
	{
		ScoreManager.EarnedScoreItem( id );
	}
}
