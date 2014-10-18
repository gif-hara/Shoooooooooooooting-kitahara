/*===========================================================================*/
/*
*     * FileName    : EnemyLookAt.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyLookAt : GameMonoBehaviour
{
	[SerializeField]
	private float lookSpeed;
	
//	[SerializeField]
//	private float lookRange;
	
	private LookAtObject refLookAtObject = null;
	
	// Use this for initialization
	public override void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	public override void Update()
	{
		base.Update();

		if( PauseManager.Instance.IsPause )	return;
		
		SetLookAtObject();
		
		if( refLookAtObject != null )
		{
			Trans.rotation = refLookAtObject.Trans.rotation;
			refLookAtObject.cachedTransform.rotation = Trans.rotation;
			
			if( refLookAtObject.refTarget == null )
			{
				enabled = false;
			}
		}
	}
	
	private void SetLookAtObject()
	{
		if( refLookAtObject != null )	return;
		if( ReferenceManager.refEnemyLayer.transform.childCount == 0 )	return;
		
		int random = Random.Range( 0, ReferenceManager.refEnemyLayer.transform.childCount );
		refLookAtObject = LookAtObject.Begin( cachedTransform, ReferenceManager.refEnemyLayer.transform.GetChild( random ), lookSpeed );
		refLookAtObject.transform.rotation = cachedTransform.rotation;
	}
}
