/*===========================================================================*/
/*
*     * FileName    : ActiveSetterOnPool.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ObjectPoolから再利用されたタイミングでアクティブフラグを設定するコンポーネント.
/// </summary>
public class ActiveSetterOnPool : MonoBehaviour, I_Poolable
{
	public enum ActionType : int
	{
		None,
		True,
		False,
	}

	[SerializeField]
	private MonoBehaviour refTarget;

	[SerializeField]
	private ActionType isAwakeActiveType;

	[SerializeField]
	private ActionType isReleaseActiveType;

	public void OnAwakeByPool( bool used )
	{
		SetActive( this.isAwakeActiveType );
	}

	public void OnReleaseByPool()
	{
		SetActive( this.isReleaseActiveType );
	}

	private void SetActive( ActionType type )
	{
		if( type == ActionType.None )
		{
			return;
		}

		refTarget.enabled = type == ActionType.True;
	}
}
