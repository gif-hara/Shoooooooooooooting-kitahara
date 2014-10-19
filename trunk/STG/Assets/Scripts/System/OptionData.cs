/*===========================================================================*/
/*
*     * FileName    : OptionData.cs
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
public static class OptionData
{
	public static SaveLoad.Option Option
	{
		get
		{
			if( option == null )
			{
				option = new SaveLoad.Option( SaveLoad.Data.option );
			}

			return option;
		}
	}
	private static SaveLoad.Option option;

	public const float DefaultSEVolume = 1.0f;

	public const float DefaultBGMVolume = 1.0f;

	public const int DefaultLife = 3;

	public static void Default()
	{
		option = new SaveLoad.Option();
	}

	public static void Remove()
	{
		option = null;
	}
}
