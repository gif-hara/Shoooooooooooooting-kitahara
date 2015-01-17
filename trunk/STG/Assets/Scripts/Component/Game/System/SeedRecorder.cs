/*===========================================================================*/
/*
*     * FileName    : SeedRecorder.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class SeedRecorder : MonoBehaviour
{
	void Start()
	{
		if( GameStatusInterfacer.GameMode == GameDefine.InputType.User )
		{
			SaveData.SeedRecord.Instance.seeds = new List<int>();
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if( GameStatusInterfacer.GameMode == GameDefine.InputType.User )
		{
			SaveData.SeedRecord.Instance.seeds.Add( Random.seed );
		}
		else
		{
			var frame = ReferenceManager.Instance.FrameCountRecorder.CurrentFrameCount;
			if( SaveData.SeedRecord.Instance.seeds[frame] != Random.seed )
			{
				Debug.LogError( "Seed not match. Frame = " + frame );
			}
		}
	}

	void OnDestroy()
	{
		SaveLoad.SaveSeedRecord();
		Debug.Log( "End" );
	}

}
