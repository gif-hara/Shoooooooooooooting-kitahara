/*===========================================================================*/
/*
*     * FileName    : InputMove.cs
*
*     * Description : キー入力による移動クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/

using UnityEngine;
using System.Collections;

public class InputMove : GameMonoBehaviour
{
	[SerializeField]
	private ObjectMoveAcceptComponent refObjectMove;
	
	// Update is called once per frame
	public override void Update()
	{
		if( PauseManager.Instance.IsPause )	return;
		
		InputArrow();
	}

	void OnPlayerSelectMode()
	{
		enabled = false;
	}

	void OnReplayMode()
	{
		enabled = false;
	}

	private void InputArrow()
	{
		if( Input.GetButton( "Up" ) || Input.GetKey( KeyCode.UpArrow ) )
		{
			refObjectMove.Up();
		}
		else if( Input.GetButton( "Down" ) || Input.GetKey( KeyCode.DownArrow ) )
		{
			refObjectMove.Down();
		}
		if( Input.GetButton( "Left" ) || Input.GetKey( KeyCode.LeftArrow ) )
		{
			refObjectMove.Left();
		}
		else if( Input.GetButton( "Right" ) || Input.GetKey( KeyCode.RightArrow ) )
		{
			refObjectMove.Right();
		}
	}
}
/* End of file ==============================================================*/
