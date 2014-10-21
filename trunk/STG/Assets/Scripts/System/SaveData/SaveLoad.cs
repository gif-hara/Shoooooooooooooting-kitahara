/*===========================================================================*/
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

	public const string SettingsFilePath = "Save/Settings.dat";

	public const string ProgressesFilePath = "Save/Progresses.dat";

	public const string ReplayDataFilePathFormat = "Save/Replay{0}.dat";
	
	
	#region セーブデータ構造
	
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

	public static SaveData.Settings LoadSettings()
	{
		return Load<SaveData.Settings>( SettingsFilePath );
	}

	public static SaveData.Progresses LoadProgresses()
	{
		return Load<SaveData.Progresses>( ProgressesFilePath );
	}

	public static ReplayData LoadReplayData( int id )
	{
		return Load<ReplayData>( string.Format( ReplayDataFilePathFormat, id.ToString( "00" ) ) );
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
	/// ファイルパスを指定してセーブデータをロードします 
	/// </summary>
	/// <param name="path">Path.</param>
	/// ファイルパス 
	public static T Load<T> (string path) where T : class, new()
	{
		T data = null;

		if(File.Exists(path))
		{
			Debug.Log("Load");
			FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter f = new BinaryFormatter();
			//読み込んで逆シリアル化する 
			data = (T)f.Deserialize(fs);
			fs.Close();
		}
		else
		{
			Debug.Log("Can't Load, " + path);
		}

		return data;
	}

	
	/// <summary>
	/// セーブデータファイルを作成します 
	/// </summary>
	public static void CrateSaveFile() {
		data = new SaveLoad();
		SaveLoad.Save();
	}
	
	/// <summary>
	/// セーブデータをセーブします 
	/// </summary>
	public static void Save ()
	{
		Save (currentFilePath);
	}

	public static void SaveSettings()
	{
		Save( SettingsFilePath, SaveData.Settings.Instance );
	}
	
	public static void SaveProgresses()
	{
		Save( ProgressesFilePath, SaveData.Progresses.Instance );
	}
	
	public static void SaveReplayData( int id, ReplayData data )
	{
		Save( string.Format( ReplayDataFilePathFormat, id.ToString( "00" ) ), data );
	}
	
	/// <summary>
	/// ファイルパスを指定してセーブデータをセーブします 
	/// </summary>
	/// <param name="path">Path.</param>
	/// ファイルパス
	public static void Save (string path)
	{
		Debug.Log("Save Path : " + path);
		if(!File.Exists(path)){
			System.IO.Directory.CreateDirectory("Save");
		}
		FileStream fs = new FileStream(path,  FileMode.Create, FileAccess.Write);
		BinaryFormatter bf = new BinaryFormatter();
		//シリアル化して書き込む 
		bf.Serialize(fs, data);
		fs.Close();
	}
	/// ファイルパスを指定してセーブデータをセーブします 
	/// </summary>
	/// <param name="path">Path.</param>
	/// ファイルパス
	public static void Save (string path, object data)
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
	#endregion	/// <summary>

}