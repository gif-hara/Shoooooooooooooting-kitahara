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
public class ScoreItemController : GameMonoBehaviour
{
	[SerializeField]
	private int id;

	/// <summary>
	/// 最初のツイーン処理.
	/// </summary>
	[SerializeField]
	private ObjectMoveTween refFirstTween;

	/// <summary>
	/// 落ちるツイーン処理.
	/// </summary>
	[SerializeField]
	private ObjectMoveTween refFallTween;

	// Use this for initialization
	public override void Start ()
	{
		refFirstTween.data.targetPosition += Trans.localPosition;
		refFallTween.data.targetPosition += Trans.localPosition;
	}
	
	public void OnPlayerCollide()
	{
		ScoreManager.EarnedScoreItem( id );
	}
}
