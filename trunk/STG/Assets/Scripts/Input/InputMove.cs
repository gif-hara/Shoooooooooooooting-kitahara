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
		if( MyInput.UpKey )
		{
			refObjectMove.Up();
		}
		else if( MyInput.DownKey )
		{
			refObjectMove.Down();
		}
		if( MyInput.LeftKey )
		{
			refObjectMove.Left();
		}
		else if( MyInput.RightKey )
		{
			refObjectMove.Right();
		}
	}
}
/* End of file ==============================================================*/
