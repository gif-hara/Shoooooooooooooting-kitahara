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

	[SerializeField]
	private int addScore;

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
	void Start ()
	{
		refFirstTween.data.targetPosition += Trans.localPosition;
		refFallTween.data.targetPosition += Trans.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void OnPlayerCollide()
	{
		GameManager.AddScore( (ulong)addScore );
	}
}
