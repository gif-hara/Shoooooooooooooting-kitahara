/*===========================================================================*/
/*
*     * FileName    : EnemyMuzzleManagerEditor.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
[CustomEditor( typeof( EnemyMuzzleManager ) )]
public class EnemyMuzzleManagerEditor : A_EditorMonoBehaviour<EnemyMuzzleManager>
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		Line();
		for( int i=0; i<Target.refMuzzleList.Count; i++ )
		{
			Enclose( i.ToString(), () =>
			{
				Horizontal( () =>
				{
					Vertical( () =>
					         {
						Target.refMuzzleList[i] = EditorGUILayout.ObjectField( "Muzzle Object", Target.refMuzzleList[i], typeof( GameObject ) ) as GameObject;
						Target.waitList[i] = IntField( "Wait", Target.waitList[i] );
					});
					Vertical( () =>
					         {
						Button( "Copy", () =>
						       {
							Target.AddMuzzleList( Target.refMuzzleList[i], Target.waitList[i] );
						});
						Button( "Delete", () =>
						       {
							Target.DeleteMuzzleList( i );
						});
					});

				});
			});
		}
		Horizontal( () =>
		{
			Button( "Add", () => Target.AddMuzzleList( null, 0 ) );
		});
	}
}
