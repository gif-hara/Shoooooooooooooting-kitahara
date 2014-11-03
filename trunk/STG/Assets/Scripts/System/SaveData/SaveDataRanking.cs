/*===========================================================================*/
/*
*     * FileName    : SaveDataRanking.cs
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
	public class Ranking
	{
		public static Ranking Instance
		{
			get
			{
				if( instance == null )
				{
					instance = SaveLoad.LoadRanking();
					if( instance == null )
					{
						instance = new Ranking();
						SaveLoad.SaveRanking();
					}
				}
				
				return instance;
			}
		}
		private static Ranking instance = null;

		public List<RankingData> DataList{ private set; get; }

		public Ranking()
		{
		}
	}
}
