/*===========================================================================*/
/*
*     * FileName    : ReplayData.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// リプレイデータ.
/// </summary>
[System.Serializable]
public class ReplayData
{
	public List<int> UpKeyList{ get{ return InputUpKeyList; } }
	private List<int> InputUpKeyList = new List<int>();

	public List<int> DownKeyList{ get{ return InputDownKeyList; } }
	private List<int> InputDownKeyList = new List<int>();

	public List<int> LeftKeyList{ get{ return InputLeftKeyList; } }
	private List<int> InputLeftKeyList = new List<int>();

	public List<int> RightKeyList{ get{ return InputRightKeyList; } }
	private List<int> InputRightKeyList = new List<int>();

	public List<int> FireKeyList{ get{ return InputFireKeyList; } }
	private List<int> InputFireKeyList = new List<int>();

	public List<int> SpecialKeyList{ get{ return InputSpecialKeyList; } }
	private List<int> InputSpecialKeyList = new List<int>();

	public List<int> ShiftKeyList{ get{ return InputShiftKeyList; } }
	private List<int> InputShiftKeyList = new List<int>();

	public int Seed{ private set; get; }

	public ReplayData( int seed )
	{
		this.Seed = seed;
	}

	public void AddUpKeyList( int frameCount )
	{
		InputUpKeyList.Add( frameCount );
	}
	public void AddDownKeyList( int frameCount )
	{
		InputDownKeyList.Add( frameCount );
	}
	public void AddLeftKeyList( int frameCount )
	{
		InputLeftKeyList.Add( frameCount );
	}
	public void AddRightKeyList( int frameCount )
	{
		InputRightKeyList.Add( frameCount );
	}
	public void AddUFireKeyList( int frameCount )
	{
		InputFireKeyList.Add( frameCount );
	}
	public void AddSpecialKeyList( int frameCount )
	{
		InputSpecialKeyList.Add( frameCount );
	}
	public void AddShiftKeyList( int frameCount )
	{
		InputShiftKeyList.Add( frameCount );
	}

	public override string ToString ()
	{
		string upKeyString = "";
		InputUpKeyList.ForEach( i =>
		{
			upKeyString += i.ToString() + " : ";
		});
		return string.Format(
			"UpKey = {0}",
			upKeyString
			);
	}
}
