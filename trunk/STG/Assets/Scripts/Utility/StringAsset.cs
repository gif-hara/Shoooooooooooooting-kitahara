/*===========================================================================*/
/*
*     * FileName    : StringAsset.cs
*
*     * Description : 文字列素材スクリプタブルオブジェクトクラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class StringAsset : ScriptableObject
{
	/// <summary>
	/// キーリスト.
	/// </summary>
	public List<string> key;
	
	/// <summary>
	/// 要素リスト.
	/// </summary>
	public List<string> asset;
	
	/// <summary>
	/// 自分自身.
	/// </summary>
	private static StringAsset instance = null;
	
	/// <summary>
	/// 検索用のディクショナリ.
	/// </summary>
	private static Dictionary<string, string> findDictionary;
	
	/// <summary>
	/// 要素追加.
	/// </summary>
	public void Add()
	{
		key.Add( "" );
		asset.Add( "" );
	}
	/// <summary>
	/// 要素削除.
	/// </summary>
	/// <param name='index'>
	/// Index.
	/// </param>
	public void Delete( int index )
	{
		key.RemoveAt( index );
		asset.RemoveAt( index );
	}
	/// <summary>
	/// 要素入れ替え.
	/// </summary>
	/// <param name='targetIndex'>
	/// Target index.
	/// </param>
	/// <param name='swapIndex'>
	/// Swap index.
	/// </param>
	public void Swap( int targetIndex, int swapIndex )
	{
		if( swapIndex <= 0 || swapIndex >= key.Count )	return;
		
		var tmpKey = key[targetIndex];
		var tmpAsset = asset[targetIndex];
		
		key[targetIndex] = key[swapIndex];
		asset[targetIndex] = asset[swapIndex];
		key[swapIndex] = tmpKey;
		asset[swapIndex] = tmpAsset;
	}
	/// <summary>
	/// 要素取得.
	/// </summary>
	/// <param name='key'>
	/// Key.
	/// </param>
	public static string Get( string key )
	{
		// 実体が無ければ新規生成.
		if( instance == null )
		{
			instance = Resources.Load( "Asset/StringAsset" ) as StringAsset;
			findDictionary = new Dictionary<string, string>();
			for( int i=0,imax=instance.key.Count; i<imax; i++ )
			{
				findDictionary.Add( instance.key[i], instance.asset[i] );
			}
		}
		
		string result;
		if( !findDictionary.TryGetValue( key, out result ) )
		{
			// 要素がない場合はエラー.
			Debug.LogError( "The specified key did not exist." );
		}
		
		return result;
	}
	/// <summary>
	/// string.Formatのラッピング.
	/// </summary>
	/// <param name='key'>
	/// Key.
	/// </param>
	/// <param name='args'>
	/// Arguments.
	/// </param>
	public static string Format( string key, params object[] args )
	{
		return string.Format( Get( key ), args );
	}
}
