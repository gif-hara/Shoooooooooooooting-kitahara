/*===========================================================================*/
/*
*     * FileName    : TitleCommandManager.cs
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
public class TitleCommandManager : MonoBehaviour
{
	public class DecideEventData
	{
		public bool IsLockInput{ private set; get; }

		public DecideEventData()
		{
			IsLockInput = false;
		}

		public void LockInput()
		{
			IsLockInput = true;
		}
	}

	[SerializeField]
	private int cursorId;

	[SerializeField]
	private GameObject refCancelEventObject;

	[SerializeField]
	private Color defaultColor;

	[SerializeField]
	private Color selectColor;

	[SerializeField]
	private List<TextMesh> refCommandTextList;

	[SerializeField]
	private List<GameObject> refDecideEventList;
	
	public const string DecideEventMessage = "OnDecideEvent";

	void Start ()
	{
		AddCursorId( 0 );
	}
	
	void Update ()
	{
		UpdateCursorId();
	}

	private void UpdateCursorId()
	{
		if( Input.GetKeyDown( KeyCode.UpArrow ) )
		{
			AddCursorId( -1 );
			SoundManager.Instance.Play( "CursorSelect" );
		}
		if( Input.GetKeyDown( KeyCode.DownArrow ) )
		{
			AddCursorId( 1 );
			SoundManager.Instance.Play( "CursorSelect" );
		}
		if( Input.GetKeyDown( KeyCode.Z ) )
		{
			DecideEventData data = new DecideEventData();
			refDecideEventList[cursorId].BroadcastMessage( DecideEventMessage, data );
			enabled = !data.IsLockInput;
		}
		if( Input.GetKeyDown( KeyCode.X ) )
		{
			refCancelEventObject.BroadcastMessage( DecideEventMessage );
		}
	}

	private void AddCursorId( int value )
	{
		cursorId += value;
		var max = refCommandTextList.Count;
		if( cursorId < 0 )
		{
			cursorId = max - 1;
		}
		if( cursorId >= max )
		{
			cursorId = 0;
		}

		SetTextMeshColor();
	}

	private void SetTextMeshColor()
	{
		refCommandTextList.ForEach( t =>
		{
			t.color = defaultColor;
		});

		refCommandTextList[cursorId].color = selectColor;
	}
}
