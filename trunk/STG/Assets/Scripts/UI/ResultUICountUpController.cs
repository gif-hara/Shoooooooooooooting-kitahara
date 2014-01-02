/*===========================================================================*/
/*
*     * FileName    : ResultUICountUpController.cs
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
public class ResultUICountUpController : GameMonoBehaviour
{
	[SerializeField]
	private int id;

	[SerializeField]
	private ResultUIManager refManager;

	[SerializeField]
	private TextMesh refTextMesh;

	private int currentNum = 0;

	public void OnStartCountUp()
	{
		StartCoroutine( CountUp() );
	}

	private IEnumerator CountUp()
	{
		int itemNum = ScoreManager.EarnedScoreItemList[id];
		while( currentNum != itemNum )
		{
			if( Input.GetKey( KeyCode.Z ) )
			{
				ScoreManager.EarnedScoreItem( id, itemNum - currentNum );
				currentNum = itemNum;
			}
			else
			{
				currentNum++;
				ScoreManager.EarnedScoreItem( id );
			}

			SoundManager.Play( "ResultCountUp" );
			refTextMesh.text = currentNum.ToString();

			yield return new WaitForEndOfFrame();
		}

		refManager.Next();
	}
}
