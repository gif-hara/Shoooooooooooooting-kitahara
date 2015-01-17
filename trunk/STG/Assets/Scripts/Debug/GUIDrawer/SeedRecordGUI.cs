/*===========================================================================*/
/*
*     * FileName    : SeedRecordGUI.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class SeedRecordGUI : A_GUIElement
{
	private SaveData.SeedRecord record = null;

	public override void Start ()
	{
		base.Start ();
		record = SaveData.SeedRecord.Instance;
	}
	public override void Draw ()
	{
		var frame = ReferenceManager.Instance.FrameCountRecorder.CurrentFrameCount;
		if( record.seeds.Count <= frame )
		{
			return;
		}
		Label( string.Format( "seed   = {0}{2}record = {1}",
		                     Random.seed,
		                     record.seeds[frame],
		                     System.Environment.NewLine ) );
	}
}
