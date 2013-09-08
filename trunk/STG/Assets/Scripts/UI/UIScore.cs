/*===========================================================================*/
/*
*     * FileName    : UIScore.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UIScore : GameMonoBehaviour
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
	
	/// <summary>
	/// 文字列キー.
	/// </summary>
	private const string AssetKey = "ScoreUIFormat";
	
	public override void LateUpdate()
	{
		base.LateUpdate();
		var message = StringAsset.Format( AssetKey, GameManager.Score );
		refTextMeshList.ForEach( (obj) =>
		{
			obj.text = message;
		});
	}
	/// <summary>
	/// 座標の設定.
	/// </summary>
	/// <param name='flag'>
	/// Flag.
	/// </param>
	public void SetPosition( Visibility vis )
	{
		var to = vis == Visibility.Visible ? initialPosition : hiddenPosition;
		TweenPosition.Begin( GO, 0.5f, to );
	}
}
