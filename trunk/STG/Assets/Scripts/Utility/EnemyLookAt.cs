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
	
	// Update is called once per frame
	public override void Update()
	{
		base.Update();

		if( PauseManager.Instance.IsPause )	return;
		
		SetLookAtObject();
		
		if( refLookAtObject != null )
		{
			cachedTransform.rotation = refLookAtObject.transform.rotation;
			refLookAtObject.transform.rotation = cachedTransform.rotation;

			var target = refLookAtObject.refTarget;
			if( target == null || !target.gameObject.activeInHierarchy )
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
