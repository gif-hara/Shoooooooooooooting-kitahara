/*===========================================================================*/
/*
*     * FileName    : CommandManager.cs
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
public class CommandManager : MonoBehaviour
{
	public class CommandEventData
	{
		public bool IsLockInput{ private set; get; }

		public CommandEventData()
		{
			IsLockInput = false;
		}

		public void LockInput()
		{
			IsLockInput = true;
		}
	}

	[System.Serializable]
	public class InputEvent
	{
		[SerializeField]
		private TextMesh refCommandTextMesh;

		[SerializeField]
		private GameObject refSelectEvent;

		[SerializeField]
		private GameObject refDecideEvent;

		public const string CommandEventMessage = "OnCommandEvent";

		public void SetCommandTextMeshColor( Color color )
		{
			refCommandTextMesh.color = color;
		}
		public CommandEventData SelectEventExecute()
		{
			return Execute( refSelectEvent );
		}
		
		public CommandEventData DecideEventExecute()
		{
			return Execute( refDecideEvent );
		}
		
		private CommandEventData Execute( GameObject targetObject )
		{
			if( targetObject == null )	return new CommandEventData();

			CommandManager.CommandEventData data = new CommandEventData();
			targetObject.SendMessage( CommandEventMessage, data );

			return data;
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
	private List<InputEvent> refInputEventList;

	void Start ()
	{
		AddCursorId( 0 );
	}
	
	void Update ()
	{
		UpdateCursorId();
	}

	public void SetCursorId( int value )
	{
		cursorId = value;
		ExecuteEvent( refInputEventList[cursorId].SelectEventExecute );
		SetTextMeshColor();
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
			ExecuteEvent( refInputEventList[cursorId].DecideEventExecute );
		}
		if( Input.GetKeyDown( KeyCode.X ) )
		{
			var data = new CommandEventData();
			refCancelEventObject.BroadcastMessage( InputEvent.CommandEventMessage, data );
			LockInput( data );
		}
	}

	private void ExecuteEvent( System.Func<CommandEventData> executeFunc )
	{
		LockInput( executeFunc() );
	}

	private void LockInput( CommandEventData data )
	{
		enabled = !data.IsLockInput;
	}

	private void AddCursorId( int value )
	{
		cursorId += value;
		var max = refInputEventList.Count;
		if( cursorId < 0 )
		{
			cursorId = max - 1;
		}
		if( cursorId >= max )
		{
			cursorId = 0;
		}

		ExecuteEvent( refInputEventList[cursorId].SelectEventExecute );
		SetTextMeshColor();
	}

	private void SetTextMeshColor()
	{
		refInputEventList.ForEach( i =>
		{
			i.SetCommandTextMeshColor( defaultColor );
		});
		refInputEventList[cursorId].SetCommandTextMeshColor( selectColor );
	}
}
