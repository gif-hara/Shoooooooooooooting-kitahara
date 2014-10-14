/*===========================================================================*/
/*
*     * FileName    : SceneManager.cs
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
public class SceneManager : A_Singleton<SceneManager>
{
	public enum EffectType : int
	{
		Default,
	}

	public class EventCatchData
	{
		private int count = 0;

		public void Catch()
		{
			count++;
		}

		public void Release()
		{
			count--;
		}

		public bool IsEndEvent
		{
			get
			{
				return count <= 0;
			}
		}
	}

	[SerializeField]
	private List<GameObject> prefabStartChangeEffectList;

	[SerializeField]
	private List<GameObject> prefabEndChangeEffectList;

	public const string StartEffectMessage = "OnStartSceneEffect";

	public override void Awake ()
	{
		Instance = this;
		base.Awake ();
	}

	public void Change( EffectType type, string sceneName )
	{
		StartCoroutine( ChangeCoroutine( type, sceneName ) );
	}

	private IEnumerator ChangeCoroutine( EffectType type, string sceneName )
	{
		var obj = Instantiate( prefabStartChangeEffectList[(int)type] ) as GameObject;
		obj.transform.parent = Trans;
		EventCatchData data = new EventCatchData();
		obj.BroadcastMessage( StartEffectMessage, data );

		while( !data.IsEndEvent )
		{
			yield return new WaitForEndOfFrame();
		}

		Application.LoadLevel( sceneName );

		Destroy( obj );

		obj = Instantiate( prefabEndChangeEffectList[(int)type] ) as GameObject;
		obj.transform.parent = Trans;
		data = new EventCatchData();
		obj.BroadcastMessage( StartEffectMessage, data );

		while( !data.IsEndEvent )
		{
			yield return new WaitForEndOfFrame();
		}

		Destroy( obj );
	}
}
