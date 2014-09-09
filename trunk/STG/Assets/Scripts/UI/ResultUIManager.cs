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
	[SerializeField]
	private List<GameObject> refCountUpObjectList;

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

	private List<GameObject> createdBackgroundStartEffect = new List<GameObject>();

	private int currentCountUpNum = 0;

	private bool endCountUp = false;

	public override void Start ()
	{
//		Next();

	}

	public override void Update ()
	{
		if( Input.GetKeyDown( KeyCode.J ) )
		{
			for( int i=0; i<createNum; i++ )
			{
				var obj = InstantiateAsChild( Trans, prefabBackgroundStartEffect.gameObject ).GetComponent<TweenMeshColor>();
				obj.SetDelay( interval * i );
				obj.transform.localPosition = new Vector2( Random.Range( rect.x, rect.width ), Random.Range( rect.y, rect.height ) );
				this.createdBackgroundStartEffect.Add( obj.gameObject );
			}
			
		}
		if( Input.GetKeyDown( KeyCode.K ) )
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
		if( !endCountUp )	return;

		if( !Input.GetKeyDown( KeyCode.Z ) )	return;

		refCountUpObjectList.ForEach( c =>
		                             {
			c.GetComponent<ResultUICountUpController>().EndEffect();
		});
	}

	public void Next()
	{
		if( refCountUpObjectList.Count == currentCountUpNum )
		{
			End();
		}
		else
		{
			NextCountUp();
		}
	}

	private void NextCountUp()
	{
		refCountUpObjectList[currentCountUpNum].SetActive( true );
		currentCountUpNum++;
	}

	private void End()
	{
		endCountUp = true;
	}
}
