/*===========================================================================*/
/*
*     * FileName    : GameStatusLoader.cs
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
public class GameStatusLoader : MonoBehaviour
{
	void Start ()
	{
		var data = SaveLoad.Data;

		if( data.setting.score == null )
		{
			Debug.Log( "score is none." );
		}
		else
		{
			for( int i=0; i<data.setting.score.Length; i++ )
			{
				Debug.Log( string.Format( "[{0}] = {1}", i, data.setting.score[i] ) );
			}
		}

		List<int> scoreList = new List<int>();
		for( int i=0; i<10; i++ )
		{
			scoreList.Add( i * 1000 );
		}
		data.setting.score = scoreList.ToArray();
		SaveLoad.Save();
	}	
	void Update ()
	{
	}
}
