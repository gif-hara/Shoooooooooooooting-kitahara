/*===========================================================================*/
/*
*     * FileName    : SaveLoad.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
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
	public class Setting {
		//ここにはゲーム設定を書き込む 
		
		public float volumeSE 		= 1f; // ボリューム設定 0～1 
		public float volumeVoice 	= 1f; // ボリューム設定 0～1 
		public float volumeBGM	 	= 1f; // ボリューム設定 0～1 
		
		public int[] score;
		
	}
	public Setting setting;
	
	[System.Serializable ()]
	public class Config {
		//ここにはキーコンフィグ設定を書き込む  
		
		
		
	}
	public Config config;
	
	#endregion
	
	
	#region セーブロードシステム(原則変更しない) 
	
	/// <summary>
	/// セーブデータのインスタンス
	/// </summary>
	static protected SaveLoad data;
	
	/// <summary>
	/// このプロパティイを通してセーブデータにアクセスします 
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
		data.setting = new SaveLoad.Setting();
		data.config = new SaveLoad.Config();
		
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