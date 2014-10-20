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

/// <summary>
/// .
/// </summary>
namespace SaveData
{
	[System.Serializable]
	public class Settings
	{
		public static Settings Instance
		{
			get
			{
				if( instance == null )
				{
					instance = SaveLoad.LoadSettings();
					if( instance == null )
					{
						instance = new Settings();
						SaveLoad.SaveSettings();
					}
				}

				return instance;
			}
		}
		private static Settings instance = null;

		public float SEVolume{ get{ return seVolume; } }
		private float seVolume;
		
		public float BGMVolume{ get{ return bgmVolume; } }
		private float bgmVolume;
		
		public int Life{ get{ return life; } }
		private int life;
		
		public Settings()
		{
			seVolume = OptionData.DefaultSEVolume;
			bgmVolume = OptionData.DefaultBGMVolume;
			life = OptionData.DefaultLife;
		}
		
		public Settings( Settings other )
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

		public void Apply( Settings other )
		{
			instance = new Settings( other );
		}
	}
}
