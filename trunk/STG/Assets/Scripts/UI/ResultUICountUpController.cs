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
using System.Collections.Generic;
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

	[SerializeField]
	private List<TweenMeshColor> refEndTweenList;

	private int currentNum = 0;

	public void OnStartCountUp()
	{
		StartCoroutine( CountUp() );
	}

	public void EndEffect()
	{
		refTextMesh.text = "";
		refEndTweenList.ForEach( t =>
		{
			t.enabled = true;
		});
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
			refTextMesh.text = StringAsset.Format( "ResultNumber", currentNum.ToString() );

			yield return new WaitForEndOfFrame();
		}

		refManager.Next();
	}
}
