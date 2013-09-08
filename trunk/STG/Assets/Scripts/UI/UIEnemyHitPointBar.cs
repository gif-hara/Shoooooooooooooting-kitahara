/*===========================================================================*/
/*
*     * FileName    : UIEnemyHitPointBar.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UIEnemyHitPointBar : GameMonoBehaviour
{
	/// <summary>
	/// バー参照.
	/// </summary>
	public UIBar refBar;
	
	/// <summary>
	/// ツイーンポジションクラス参照.
	/// </summary>
	public TweenPosition refTweenPosition;
	
	/// <summary>
	/// 敵参照.
	/// </summary>
	private EnemyController refEnemy;
	
	/// <summary>
	/// ヒットポイントをバーと同期を取るか.
	/// </summary>
	private bool isSyncHp = false;
	
	private const int StartEffectTime = 60;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
		ReferenceManager.refScore.SetPosition( UIScore.Visibility.Hidden );
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();
		UpdateBar();
	}
	/// <summary>
	/// 初期化.
	/// </summary>
	/// <param name='enemy'>
	/// Enemy.
	/// </param>
	public void Initialize( EnemyController enemy )
	{
		isSyncHp = false;
		refEnemy = enemy;
		refBar.Initialize( enemy.MaxHp, 0.0f );
	}
	/// <summary>
	/// 開始演出の開始.
	/// </summary>
	public void StartEffect()
	{
		StartCoroutine( StartEffectCoroutine() );
	}
	/// <summary>
	/// 終了演出の開始.
	/// </summary>
	public void EndEffect()
	{
		ReferenceManager.refScore.SetPosition( UIScore.Visibility.Visible );
		
		TweenPosition.Begin( refTweenPosition.gameObject, refTweenPosition.duration, refTweenPosition.from );
		refTweenPosition.callWhenFinished = "Destroy";
	}
	/// <summary>
	/// 死亡処理.
	/// </summary>
	public void Destroy()
	{
		Destroy( gameObject );
	}
	/// <summary>
	/// 開始演出コルーチン処理.
	/// </summary>
	/// <returns>
	/// The effect coroutine.
	/// </returns>
	private IEnumerator StartEffectCoroutine()
	{
		int t = StartEffectTime;
		while( t >= 0 )
		{
			refBar.Current = Mathf.Lerp( 0, refEnemy.MaxHp, (float)(StartEffectTime - t) / StartEffectTime );
			t--;
			yield return new WaitForEndOfFrame();
		}
		
		isSyncHp = true;
	}
	/// <summary>
	/// バーUI更新処理.
	/// </summary>
	private void UpdateBar()
	{
		if( !isSyncHp )	return;
		
		refBar.Current = refEnemy.Hp;
	}
}
