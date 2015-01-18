/*===========================================================================*/
/*
*     * FileName    : CharListManager.cs
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
public class CharListManager : MonoBehaviour
{
	[SerializeField]
	private GameObject prefabElement;

	[SerializeField]
	private RankingDataBuilder refRankingDataBuilder;

	[SerializeField]
	private GameObject refCommandManager;

	[SerializeField]
	private GameObject refConfirmObject;

	[SerializeField]
	private string createCharList;

	[SerializeField]
	private float interval;

	[SerializeField]
	private float velocity;

	private int cursorId = 0;

	private string userName = "";

	// Use this for initialization
	void Start ()
	{
		for( int i=0,imax=createCharList.Length; i<imax; i++ )
		{
			var element = GameMonoBehaviour.InstantiateAsChild( transform, prefabElement ).GetComponent<CharObserver>();
			element.Content = createCharList[i];
			element.transform.localPosition = new Vector3( interval * i, 0.0f, 0.0f );
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdatePosition();
	}

	public void AddCursorId( int value )
	{
		cursorId += value;
		cursorId = cursorId < 0 ? 0 : cursorId;
		var max = createCharList.Length - 1;
		cursorId = cursorId > max ? max : cursorId;
	}

	public void AddChar()
	{
		if( userName.Length >= 3 )
		{
			return;
		}

		userName += createCharList[cursorId];
		refRankingDataBuilder.SetUserName( userName );

		if( userName.Length >= 3 )
		{
			refCommandManager.SetActive( false );
			refConfirmObject.SetActive( true );
		}
	}

	public void DeleteChar()
	{
		if( userName.Length <= 0 )
		{
			return;
		}

		userName = userName.Remove( userName.Length - 1, 1 );
		refRankingDataBuilder.SetUserName( userName );
	}

	private void UpdatePosition()
	{
		var target = new Vector3( -interval * cursorId, 0.0f, 0.0f );
		transform.localPosition += (target - transform.localPosition) * velocity;
	}
}
