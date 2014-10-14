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
	[SerializeField]
	private Color defaultColor;

	[SerializeField]
	private Color selectColor;

	[SerializeField]
	private List<TextMesh> refCommandTextList;

	private int cursorId = 0;

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
			SoundManager.Instance.Play( "CursorDecide" );
			SceneManager.Instance.Change( SceneManager.EffectType.Default, "Main" );
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
