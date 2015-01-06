/*===========================================================================*/
/*
*     * FileName    : SettingsSaveData.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SaveData
{
	[System.Serializable]
	public class Progresses
	{
		public static Progresses Instance
		{
			get
			{
				if( instance == null )
				{
					instance = SaveLoad.LoadProgresses();
					if( instance == null )
					{
						instance = new Progresses();
						SaveLoad.SaveProgresses();
					}
				}
				
				return instance;
			}
		}
		private static Progresses instance = null;

		public List<List<bool>> StageClearFrag{ private set; get; }

		public Progresses()
		{
			this.StageClearFrag = new List<List<bool>> ();
			var difficultyList = System.Enum.GetValues ( typeof( GameDefine.DifficultyType ) );
			for( int i=0; i<difficultyList.Length; i++ )
			{
				this.StageClearFrag.Add( new List<bool>() );
				for (int j=0; j<7; j++)
				{
					this.StageClearFrag[i].Add( false );
				}
			}
		}

		public void StageClear( GameDefine.DifficultyType difficulty, int id )
		{
			this.StageClearFrag[(int)difficulty][id] = true;
		}

		public bool IsClear( GameDefine.DifficultyType difficulty, int id )
		{
			return this.StageClearFrag[(int)difficulty][id];
		}

		public void DebugAllClear()
		{
			var difficultyList = System.Enum.GetValues ( typeof( GameDefine.DifficultyType ) );
			for( int i=0; i<difficultyList.Length; i++ )
			{
				for (int j=0; j<7; j++)
				{
					this.StageClearFrag[i][j] = true;
				}
			}

			SaveLoad.SaveProgresses();
		}
	}
}
