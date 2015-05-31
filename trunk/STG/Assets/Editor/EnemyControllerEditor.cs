/*===========================================================================*/
/*
*     * FileName    : EnemyControllerEditor.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

//[CustomEditor( typeof( EnemyController ) )]
//public class EnemyControllerEditor : A_EditorMonoBehaviour<EnemyController>
//{
//	public override void OnInspectorGUI()
//	{
//		base.OnInspectorGUI();
//		OnInspectorSetShotCreatorList();
//	}
//	private void OnInspectorSetShotCreatorList()
//	{
//		Button( "Set ShotCreatorList", () =>
//		{
//			Target.refShotCreatorList.Clear();
//			Target.refShotCreatorList.AddRange( Target.Trans.GetComponentsInChildren<EnemyShotCreator>() );
//		});
//		Button( "Create Damage Event", () =>
//		{
//			var obj = new GameObject( "DamageEvent" );
//			obj.transform.parent = Target.transform;
//			obj.transform.localPosition = Vector3.zero;
//			Target.DamageEventObject = obj;
//
//			var flash = obj.AddComponent<DamageEventTextureFlash>();
//			flash.refEnemy = Target;
//		});
//	}
//}
