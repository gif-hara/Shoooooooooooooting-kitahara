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

	public int PlayerId{ private set; get; }

	public int StageId{ private set; get; }

	public GameDefine.StageType StageType{ private set; get; }

	public bool IsValid{ private set; get; }

	public int Version{ private set; get; }

	public long TimeStamp{ private set; get; }

	public ReplayData()
	{
		this.IsValid = false;
	}

	public ReplayData( int seed, int playerId, int stageId )
	{
		this.PlayerId = playerId;
		this.StageId = stageId;
		this.Seed = seed;
		this.IsValid = true;

		this.Version = 100;
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

	public void End( GameDefine.StageType stageType )
	{
		this.StageType = stageType;
		this.TimeStamp = System.DateTime.Now.Ticks;
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
