/*===========================================================================*/
/*
*     * FileName    : ResultUIManager.cs
*
*     * Description : リザルトUI管理者クラス.
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// リザルトUI管理者クラス.
/// </summary>
public class ResultUIManager : GameMonoBehaviour
{
	public class EffectData
	{
		public int effectId;

		public int receivedCount;

		public EffectData( int effectId )
		{
			this.effectId = effectId;
			this.receivedCount = 0;
		}
	}
	[SerializeField]
	private TweenMeshColor prefabBackgroundStartEffect;

	[SerializeField]
	private TweenMeshColor prefabBackgroundEndEffect;

	[SerializeField]
	private Rect rect;

	[SerializeField]
	private int createNum;

	[SerializeField]
	private int interval;

	[SerializeField]
	private int startEffectEndDelay;

	[SerializeField]
	private List<GameObject> refEffectObjects;

	private int effectObjectExecuteId = 0;

	private int effectSequenceId = 0;

	private int receivedEffectTask = 0;

	private List<GameObject> createdBackgroundStartEffect = new List<GameObject>();

	private const string ExecuteMessage = "OnEffectExecute";

	public const string CompleteMessage = "OnCompleteEffectModule";

//	public override void Update ()
//	{
//		base.Update ();
//		if( Input.GetKeyDown( KeyCode.J ) )
//		{
//			StartEffect();
//		}
//	}
	void OnStartResult()
	{
		StartEffect();
	}

	void OnStartStage()
	{
		EndEffect();
	}

	void OnCompleteEffectModule()
	{
		this.receivedEffectTask--;
		Debug.Log( "OnCompleteEffectModule this.receivedEffectTask = " + this.receivedEffectTask );

		if( this.receivedEffectTask == 0 )
		{
			EnumerateResultUI();
		}
	}

	private void StartEffect()
	{
		this.receivedEffectTask = 0;
		this.effectObjectExecuteId = 0;
		this.effectSequenceId = 0;

		for( int i=0; i<createNum; i++ )
		{
			var obj = InstantiateAsChild( Trans, prefabBackgroundStartEffect.gameObject ).GetComponent<TweenMeshColor>();
			obj.SetDelay( interval * i );
			obj.transform.localPosition = new Vector2( Random.Range( rect.x, rect.width ), Random.Range( rect.y, rect.height ) );
			this.createdBackgroundStartEffect.Add( obj.gameObject );
		}

		FrameRateUtility.StartCoroutine( startEffectEndDelay, EnumerateResultUI );
	}

	private void EndEffect()
	{
		this.createdBackgroundStartEffect.RemoveAll( g => g == null );
		for( int i=0, imax=this.createdBackgroundStartEffect.Count; i<imax; i++ )
		{
			var obj = InstantiateAsChild( Trans, prefabBackgroundEndEffect.gameObject ).GetComponent<TweenMeshColor>();
			obj.SetDelay( interval * (imax - i) );
			obj.transform.localPosition = this.createdBackgroundStartEffect[i].transform.localPosition;
		}
		this.createdBackgroundStartEffect.ForEach( g => Destroy( g ) );
	}

	private void EnumerateResultUI()
	{
		var effectObject = this.refEffectObjects[this.effectObjectExecuteId];
		Debug.Log( effectObject.name );
		var effectData = new EffectData( this.effectSequenceId );
		effectObject.BroadcastMessage( ExecuteMessage, effectData, SendMessageOptions.RequireReceiver );
		this.receivedEffectTask += effectData.receivedCount;
		this.effectSequenceId++;
		Debug.Log( "this.receivedEffectTask = " + this.receivedEffectTask );

		if( this.receivedEffectTask == 0 )
		{
			effectObjectExecuteId++;

			if( this.refEffectObjects.Count == effectObjectExecuteId )
			{
				EndResult();
			}
			else
			{
				effectSequenceId = 0;
				EnumerateResultUI();
			}
		}
	}

	private void EndResult()
	{
		ReferenceManager.refScoreManager.InitStarItem();
		ReferenceManager.refStageManager.BroadcastMessage( GameDefine.EndResultMessage );
	}
}
