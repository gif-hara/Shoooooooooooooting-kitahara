﻿/*===========================================================================*/
/*
*     * FileName    : SaveLoad.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// セーブやロードを扱うクラスです 
/// PC, Mac, Androidで使用できます 
/// （BinaryFormatterを扱えないiOSなどでは利用できません） 
/// https://github.com/KentaYanase/KentaYanase/blob/master/Unity/SaveLoad/SaveLoad.cs
/// </summary>
[System.Serializable ()]
public class SaveLoad
{
	
	/// <summary>
	/// セーブデータファイルのパス
	/// </summary>
	public static string currentFilePath = "Save/SaveData.dat"; 
	
	
	#region セーブデータ構造
	
	[System.Serializable ()]
	public class ReplayDataList
	{
		public ReplayData this[int i]{ get{ return list[i]; } }
		private List<ReplayData> list;

		public const int Capacity = 30;

		public ReplayDataList()
		{
			list = new List<ReplayData>( Capacity );
			for( int i=0; i<Capacity; i++ )
			{
				list.Add( new ReplayData( 0 ) );
			}
		}

		public void Set( int id, ReplayData data )
		{
			list[id] = data;
		}
	}
	public ReplayDataList replayDataList;

	[System.Serializable]
	public class Option
	{
		public float SEVolume{ get{ return seVolume; } }
		private float seVolume;
		
		public float BGMVolume{ get{ return bgmVolume; } }
		private float bgmVolume;
		
		public int Life{ get{ return life; } }
		private int life;
		
		public Option()
		{
			seVolume = OptionData.DefaultSEVolume;
			bgmVolume = OptionData.DefaultBGMVolume;
			life = OptionData.DefaultLife;
		}
		
		public Option( Option other )
		{
			seVolume = other.seVolume;
			bgmVolume = other.bgmVolume;
			life = other.life;
		}

		public void AddSEVolume( float value )
		{
			seVolume = Mathf.Clamp( seVolume + value, 0.0f, 1.0f );
		}
		public void AddBGMVolume( float value )
		{
			bgmVolume = Mathf.Clamp( bgmVolume + value, 0.0f, 1.0f );
		}
		public void AddLifeVolume( int value )
		{
			life = Mathf.Clamp( life + value, 1, 6 );
		}
	}
	public Option option;


	#endregion
	
	
	#region セーブロードシステム(原則変更しない) 
	
	/// <summary>
	/// セーブデータのインスタンス
	/// </summary>
	static protected SaveLoad data;
	
	/// <summary>
	/// このプロパティを通してセーブデータにアクセスします 
	/// </summary>
	public static SaveLoad Data {
		get {
			if(data == null) {
				SaveLoad.Load();
			}
			return data;
		}
	}
	
	/// <summary>
	/// コンストラクタ 
	/// </summary>
	public SaveLoad () {
	}
	
	/// <summary>
	/// セーブデータをロードします 
	/// </summary>
	public static void Load ()
	{
		Load (currentFilePath);
	}
	
	/// <summary>
	/// ファイルパスを指定してセーブデータをロードします 
	/// </summary>
	/// <param name="path">Path.</param>
	/// ファイルパス 
	public static void Load (string path)
	{
		//		data = new SaveLoad();
		
		if(File.Exists(path)){
			Debug.Log("Load");
			FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter f = new BinaryFormatter();
			//読み込んで逆シリアル化する 
			data = (SaveLoad)f.Deserialize(fs);
			fs.Close();
		}else {
			Debug.Log("Can't Load, Make Save.dat");
			//セーブデータファイルが存在していなければ作成します 
			CrateSaveFile();
		}
	}
	
	
	/// <summary>
	/// セーブデータファイルを作成します 
	/// </summary>
	public static void CrateSaveFile() {
		data = new SaveLoad();
		data.replayDataList = new ReplayDataList();
		data.option = new Option();
		SaveLoad.Save();
	}
	
	/// <summary>
	/// セーブデータをセーブします 
	/// </summary>
	public static void Save ()
	{
		Save (currentFilePath);
	}
	
	/// <summary>
	/// ファイルパスを指定してセーブデータをセーブします 
	/// </summary>
	/// <param name="path">Path.</param>
	/// ファイルパス
	public static void Save (string path)
	{
		Debug.Log("Save");
		if(!File.Exists(path)){
			System.IO.Directory.CreateDirectory("Save");
		}
		FileStream fs = new FileStream(path,  FileMode.Create, FileAccess.Write);
		BinaryFormatter bf = new BinaryFormatter();
		//シリアル化して書き込む 
		bf.Serialize(fs, data);
		fs.Close();
	}
	#endregion
}