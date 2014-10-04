/*===========================================================================*/
/*
*     * FileName    : UIScoreBase.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public abstract class UIScoreBase : GameMonoBehaviour
{
	public enum Visibility : int
	{
		Visible,
		Hidden
	}

	/// <summary>
	/// スコアを描画するテキストメッシュ参照リスト.
	/// </summary>
	public List<TextMesh> refTextMeshList;
	
	/// <summary>
	/// 初期座標.
	/// </summary>
	public Vector3 initialPosition;
	
	/// <summary>
	/// 文字部分が隠れる座標.
	/// </summary>
	public Vector3 hiddenPosition;

	public override void Start ()
	{
		OnModifiedScore();
	}
	void OnModifiedScore()
	{
		var message = StringAsset.Format( AssetKey, DrawValue );
		refTextMeshList.ForEach( (obj) =>
		                        {
			obj.text = message;
		});
	}
	void OnStartBossBattle()
	{
		SetPosition( Visibility.Hidden );
	}
	void OnEndBossBattle()
	{
		SetPosition( Visibility.Visible );
	}
	/// <summary>
	/// 座標の設定.
	/// </summary>
	/// <param name='flag'>
	/// Flag.
	/// </param>
	private void SetPosition( Visibility vis )
	{
		var to = vis == Visibility.Visible ? initialPosition : hiddenPosition;
		TweenPosition.Begin( GO, 0.5f, to );
	}

	protected abstract string AssetKey{ get; }

	protected abstract ulong DrawValue{ get; }
}