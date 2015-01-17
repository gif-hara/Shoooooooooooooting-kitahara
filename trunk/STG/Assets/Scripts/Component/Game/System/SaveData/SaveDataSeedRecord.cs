/*===========================================================================*/
/*
*     * FileName    : SaveDataSeedRecord.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

namespace SaveData
{
	[System.Serializable]
	public class SeedRecord
	{
		public static SeedRecord Instance
		{
			get
			{
				if( instance == null )
				{
					instance = SaveLoad.LoadSeedRecord();
					if( instance == null )
					{
						instance = new SeedRecord();
						SaveLoad.SaveSeedRecord();
					}
				}
				
				return instance;
			}
		}
		private static SeedRecord instance = null;

		public List<int> seeds;
		

		public SeedRecord()
		{
			seeds = new List<int>();
		}
		
	}
}
