/*===========================================================================*/
/*
*     * FileName    : CommandEventSetTitleDecideStageId.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

public class CommandEventSetTitleDecideStageId : MonoBehaviour 
{
	[SerializeField]
	private int id;

	void OnCommandEvent()
	{
		GameStatusInterfacer.StageId = id;
		GameStatusInterfacer.TitleDecideStageId = id;
	}

	void OnCreatedPracticeStageElement( int id )
	{
		this.id = id;
	}
}
