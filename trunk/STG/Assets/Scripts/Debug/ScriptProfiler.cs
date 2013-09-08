/*===========================================================================*/
/*
*     * FileName    : ScriptProfiler.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
//#define USE_PROFILE
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class ScriptProfiler : GameMonoBehaviour
{
#if USE_PROFILE
	public class BenchMarkData
	{
		private float startTime;
		
		private float result;
		
		public BenchMarkData()
		{
			startTime = Time.realtimeSinceStartup;
		}
		
		public void End()
		{
			result = Time.realtimeSinceStartup - startTime;
		}
		
		public float Result
		{
			get
			{
				return result;
			}
		}
	}
	
	public class BenchMarkListData
	{
		private string scriptName;
		
		List<BenchMarkData> dataList;
		
		public BenchMarkListData( string scriptName )
		{
			this.scriptName = scriptName;
			dataList = new List<BenchMarkData>();
		}
		public void Add()
		{
			dataList.Add( new BenchMarkData() );
		}
		public string ScriptName
		{
			get
			{
				return scriptName;
			}
		}
		public int Count
		{
			get
			{
				return dataList.Count;
			}	
		}
		public List<BenchMarkData> DataList
		{
			get
			{
				return dataList;
			}
		}
	}
	
	private GUIText myGUIText;
	
	private static Dictionary<string, BenchMarkListData> dataDictionary = new Dictionary<string, BenchMarkListData>();
	
	// Use this for initialization
	void Start()
	{
		myGUIText = guiText;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		Report();
	}
	/// <summary>
	/// スクリプトベンチマークの開始.
	/// </summary>
	/// <param name='scriptName'>
	/// スクリプト名.
	/// </param>
	public static int Begin( object obj )
	{
		BenchMarkListData list = null;
		if( dataDictionary.TryGetValue( obj.GetType().ToString(), out list ) )
		{
			int result = list.Count;
			list.Add();
			
			return result;
		}
		else
		{
			var data = new BenchMarkListData( obj.GetType().ToString() );
			data.Add();
			dataDictionary.Add( obj.GetType().ToString(), data );
			
			return 0;
		}
	}
	/// <summary>
	/// スクリプトベンチマークの終了.
	/// </summary>
	/// <param name='scriptName'>
	/// スクリプト名.
	/// </param>
	/// <param name='id'>
	/// Begin関数で返したID.
	/// </param>
	public static void End( object obj, int id )
	{
		dataDictionary[obj.GetType().ToString()].DataList[id].End();
	}
	
	private void Report()
	{
		StringBuilder builder = new StringBuilder();
		foreach( var list in dataDictionary.Values )
		{
			float result = 0.0f;
			foreach( var data in list.DataList )
			{
				result += data.Result;
			}
			builder.AppendFormat( "{0} : {1}{2}", list.ScriptName, result.ToString( "0.00000" ), System.Environment.NewLine );
		}
		
		myGUIText.text = builder.ToString();
		
		dataDictionary = new Dictionary<string, BenchMarkListData>();
	}
#else
	/// <summary>
	/// スクリプトベンチマークの開始.
	/// </summary>
	/// <param name='scriptName'>
	/// スクリプト名.
	/// </param>
	public static int Begin( object obj )
	{
		return 0;
	}
	/// <summary>
	/// スクリプトベンチマークの終了.
	/// </summary>
	/// <param name='scriptName'>
	/// スクリプト名.
	/// </param>
	/// <param name='id'>
	/// Begin関数で返したID.
	/// </param>
	public static void End( object obj, int id )
	{
	}
#endif
}
