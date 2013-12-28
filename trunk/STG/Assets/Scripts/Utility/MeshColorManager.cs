//================================================
/*!
    @file   MeshColorManager.cs

    @brief  メッシュカラー管理者クラス.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// メッシュカラー管理者クラス.
/// </summary>
public class MeshColorManager
{
	/// <summary>
	/// メッシュリスト.
	/// </summary>
	private List<Mesh> meshList = null;

	/// <summary>
	/// 現在の色.
	/// </summary>
	private Color currentColor = Color.white;

	/// <summary>
	/// 初期化.
	/// </summary>
	/// <param name="rendererList">Renderer list.</param>
	public void Initialize( List<Renderer> rendererList )
	{
		meshList = new List<Mesh>();
		rendererList.ForEach( (obj) =>
		{
			meshList.Add( obj.GetComponent<MeshFilter>().mesh );
		});
	}

	public void Initialize( MeshFilter meshFilter )
	{
		meshList = new List<Mesh>();
		meshList.Add( meshFilter.mesh );
	}
	/// <summary>
	/// 色の設定.
	/// </summary>
	/// <param name="color">Color.</param>
	public void SetColor( Color color )
	{
		// 処理軽減のため同じ色だった場合は何もしない.
		if( currentColor == color )	return;

		currentColor = color;
		meshList.ForEach( (obj) =>
		{
			Color[] colors = new Color[obj.colors.Length];
			for( int i=0,imax=colors.Length; i<imax; i++ )
			{
				colors[i] = color;
			}
			obj.colors = colors;
		});
	}
}