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
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class StringAsset : ScriptableObject
{
	public List<string> key;
	public List<string> asset;
	
	private static StringAsset instance = null;
	private static Dictionary<string, string> findDictionary;
	
	public void Add()
	{
		key.Add( "" );
		asset.Add( "" );
	}
	
	public void Delete( int index )
	{
		key.RemoveAt( index );
		asset.RemoveAt( index );
	}
	
	public static string Get( string key )
	{
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
			Debug.LogError( "The specified key did not exist." );
		}
		
		return result;
	}
	
	public static string Format( string key, params object[] args )
	{
		return string.Format( Get( key ), args );
	}
}
