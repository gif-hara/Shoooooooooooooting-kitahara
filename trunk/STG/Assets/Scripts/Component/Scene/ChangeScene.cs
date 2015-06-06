/*===========================================================================*/
/*
*     * FileName    : ChangeScene.cs
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
public class ChangeScene : MonoBehaviour
{
	[SerializeField]
	protected SceneManager.EffectType startEffectType;

	[SerializeField]
	protected SceneManager.EffectType endEffectType;

	[SerializeField]
	protected string sceneName;

	[SerializeField]
	private bool isImmediate = false;

	void Start()
	{
		if( this.isImmediate )
		{
			this.Change();
		}
	}

	public void Change()
	{
		SceneManager.Instance.Change( startEffectType, endEffectType, sceneName );
	}

	public void SetSceneName( string sceneName )
	{
		this.sceneName = sceneName;
	}
}
