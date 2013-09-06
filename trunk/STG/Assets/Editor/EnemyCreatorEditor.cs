/*===========================================================================*/
/*
*     * FileName    : EnemyCreatorEditor.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

[CanEditMultipleObjects]
[CustomEditor( typeof( EnemyCreator ) )]
public class EnemyCreatorEditor : A_StageTimeLineActionEditor<EnemyCreator>
{
	/// <summary>
	/// 移動データタイプID.
	/// </summary>
	private int dataTypeId = 0;
		
	void OnEnable()
	{
		Target.isIconDraw = true;
	}
	void OnDisable()
	{
		Target.isIconDraw = false;
	}
	void OnSceneGUI()
	{
		Target.initialPosition = Handles.PositionHandle( Target.initialPosition, Quaternion.identity );
		Handles.Label( Target.initialPosition, "InitialPosition" );
		
		for( int i=0,imax=Target.dataList.Count; i<imax; i++ )
		{
			DrawOnSceneViewData( Target.dataList[i].moveType.ToString(), Target.dataList[i] );
		}
	}
	public override void OnInspectorGUI()
	{
		// 設定しているオブジェクトが単体の場合
		if( targets.Length == 1 )
		{
			Enclose( "Property", () =>
			{
				DrawTimeLine();
				DrawEnemyId();
				DrawInitialPosition();
			}, true );
			Enclose( "Move Data List", () =>
			{
				Enclose( "System", () =>
				{
					DrawDataCreateButton();
				}, true );
				DrawDataList();
			});
		}
		else
		{
			Enclose( "Multi Setting", () =>
			{
				DrawTargetsMultiSetting();
				DrawTimeLineMultiSetting();
				DrawInitialPositionMultiSetting();
			}, true, false );
		}
	}
#region Property Draw Method
	private void DrawEnemyId()
	{
		Horizontal( () =>
		{
			int oldEnemyId = Target.enemyId;
			Target.enemyId = EditorGUILayout.IntField( "Enemy Id", Target.enemyId );
			
			float buttonSize = 30.0f;
			Button( "+", () =>
			{
				Target.enemyId++;
			}, Width( buttonSize ) );
			Button( "-", () =>
			{
				Target.enemyId--;
			}, Width( buttonSize ));
			
			int max = StageCreator.EnemyPrefabList.Count - 1;
			Target.enemyId = Target.enemyId > max ? max : Target.enemyId;
			Target.enemyId = Target.enemyId < 0 ? 0 : Target.enemyId;
			
			if( oldEnemyId != Target.enemyId )
			{
				Target.SyncData();
			}
		});
	}
	
	private void DrawInitialPosition()
	{
		Horizontal( () =>
		{
			Vector3 initialPosition = EditorGUILayout.Vector3Field( "Initial Position", Target.initialPosition );
			if( initialPosition != Target.initialPosition )
			{
				Target.initialPosition = initialPosition;
				SceneView.RepaintAll();
			}
		});
	}
#endregion
#region Move Data List Method
	private void DrawDataCreateButton()
	{
		Horizontal( () =>
		{
			dataTypeId = EditorGUILayout.IntPopup( dataTypeId, ObjectMoveUtility.MoveTypeStrings, ObjectMoveUtility.MoveTypeIdList );
			Button( "Create", () =>
			{
				var t = new A_ObjectMove.Data( (ObjectMoveUtility.MoveType)dataTypeId );
				Target.dataList.Add( t );
				
				SceneView.RepaintAll();
			});
		});
	}
	
	private void DrawDataList()
	{
		for( int i=0,imax=Target.dataList.Count; i<imax; i++ )
		{
			DrawOnInspectorData( Target.dataList[i].moveType.ToString(), (A_ObjectMove.Data)Target.dataList[i] );
			DrawOnInspectorDataSystem( i );
		}
	}
	private void DrawOnInspectorData( string typeName, A_ObjectMove.Data data )
	{
		System.Action<A_ObjectMove.Data>[] func =
		{
			DrawOnInspectorObjectMoveTween,
			DrawOnInspectorObjectMoveChasePlayer,
			DrawOnInspectorObjectMoveRandomRect,
		};
		
		int id = ObjectMoveUtility.MoveTypeStringsToList.FindIndex( (obj) => obj == typeName );
		func[id]( data );
	}
	private void DrawOnInspectorDataSystem( int id )
	{
		Enclose( "Data System", () =>
		{
			Horizontal( () =>
			{
				Button( "↑", () =>
				{
					if( id != 0 )
					{
						var data0 = Target.dataList[id-1];
						Target.dataList[id-1] = Target.dataList[id];
						Target.dataList[id] = data0;
					}
				});
				Button( "↓", () =>
				{
					if( Target.dataList.Count - 1 > id )
					{
						var data0 = Target.dataList[id+1];
						Target.dataList[id+1] = Target.dataList[id];
						Target.dataList[id] = data0;
					}
				});
				Button( "Delete", () =>
				{
					Target.dataList.RemoveAt( id );
				});
				Button( "Copy*", () =>
				{
					// ToDo:要実装.
				});
			});
		});
	}
	private void DrawOnSceneViewData( string typeName, A_ObjectMove.Data data )
	{
		System.Action<A_ObjectMove.Data>[] func =
		{
			DrawOnSceneViewObjectMoveTween,
			DrawOnSceneViewObjectMoveChasePlayer,
			DrawOnSceneViewObjectMoveRandomRect,
		};
		
		int id = ObjectMoveUtility.MoveTypeStringsToList.FindIndex( (obj) => obj == typeName );
		func[id]( data );
	}
#endregion
#region      Draw OnSceneView
	private void DrawOnSceneViewObjectMoveTween( A_ObjectMove.Data data )
	{
		data.targetPosition = Handles.PositionHandle( data.targetPosition, Quaternion.identity );
		Handles.Label( data.targetPosition, "TargetPosition" );
	}
	private void DrawOnSceneViewObjectMoveChasePlayer( A_ObjectMove.Data data )
	{
	}
	private void DrawOnSceneViewObjectMoveRandomRect( A_ObjectMove.Data data )
	{
		var rect = data.rect;
		Handles.DrawLine( new Vector3( rect.x, rect.y, 0.0f ), new Vector3( rect.x, rect.height, 0.0f ) );
		Handles.DrawLine( new Vector3( rect.x, rect.y, 0.0f ), new Vector3( rect.width, rect.y, 0.0f ) );
		Handles.DrawLine( new Vector3( rect.width, rect.y, 0.0f ), new Vector3( rect.width, rect.height, 0.0f ) );
		Handles.DrawLine( new Vector3( rect.x, rect.height, 0.0f ), new Vector3( rect.width, rect.height, 0.0f ) );
		Handles.Label( new Vector3( rect.x, rect.y, 0.0f ), "Range" );
	}
#endregion //Draw OnSceneView
#region      Draw OnInspector
	private void DrawOnInspectorObjectMoveDelayFrame( A_ObjectMove.Data data )
	{
		data.delayFrame = IntField( "Delay Frame", data.delayFrame );
	}
	protected void DrawOnInspectorObjectMoveIsDestroy( A_ObjectMove.Data data )
	{
		data.isDestroy = EditorGUILayout.Toggle( "Is Destroy", data.isDestroy );
	}
	protected void DrawOnInspectorObjectMoveSpeed( A_ObjectMove.Data data )
	{
		data.speed = EditorGUILayout.FloatField( "Speed", data.speed );
	}
	protected void DrawOnInspectorObjectMoveIsOverDistance( A_ObjectMove.Data data )
	{
		data.isOnOverDistance = EditorGUILayout.Toggle( "Is Over Distance", data.isOnOverDistance );
	}
	protected void DrawOnInspectorObjectMoveIsSyncRotation( A_ObjectMove.Data data )
	{
		data.isSyncRotation = EditorGUILayout.Toggle( "Is Sync Rotation", data.isSyncRotation );
	}
	private void DrawOnInspectorObjectMoveTargetPosition( A_ObjectMove.Data data )
	{
		var oldTargetPosition = EditorGUILayout.Vector3Field( "Target Position", data.targetPosition );;
		if( oldTargetPosition != data.targetPosition )
		{
			data.targetPosition = oldTargetPosition;
			SceneView.RepaintAll();
		}
	}
	private void DrawOnInspectorObjectMoveCurve0( A_ObjectMove.Data data, string text = "Curve 0" )
	{
		data.curve0 = EditorGUILayout.CurveField( text, data.curve0 );
	}
	private void DrawOnInspectorObjectMoveCurve1( A_ObjectMove.Data data, string text = "Curve 1" )
	{
		data.curve1 = EditorGUILayout.CurveField( text, data.curve1 );
	}
	private void DrawOnInspectorObjectMoveDurationFrame( A_ObjectMove.Data data )
	{
		data.durationFrame = EditorGUILayout.IntField( "Duration Frame", data.durationFrame );
	}
	private void DrawOnInspectorObjectMoveRect( A_ObjectMove.Data data, string text = "Rect" )
	{
		data.rect = EditorGUILayout.RectField( text, data.rect );
		SceneView.RepaintAll();
	}
	private void DrawOnInspectorObjectMoveInitFuncName( A_ObjectMove.Data data )
	{
		data.initFuncName = EditorGUILayout.TextField( "Init Func", data.initFuncName );
	}
	private void DrawOnInspectorObjectMoveTween( A_ObjectMove.Data data )
	{
		Enclose( "Tween", () =>
		{
			Vertical( () =>
			{
				DrawOnInspectorObjectMoveTargetPosition( data );
				DrawOnInspectorObjectMoveCurve0( data, "Move Curve" );
				DrawOnInspectorObjectMoveDelayFrame( data );
				DrawOnInspectorObjectMoveDurationFrame( data );
				DrawOnInspectorObjectMoveIsDestroy( data );
				DrawOnInspectorObjectMoveInitFuncName( data );
			});
		});
	}
	private void DrawOnInspectorObjectMoveChasePlayer( A_ObjectMove.Data data )
	{
		Enclose( "Chase Player", () =>
		{
			Vertical( () =>
			{
				DrawOnInspectorObjectMoveTargetPosition( data );
				DrawOnInspectorObjectMoveCurve0( data, "Speed Curve" );
				DrawOnInspectorObjectMoveDelayFrame( data );
				DrawOnInspectorObjectMoveDurationFrame( data );
				DrawOnInspectorObjectMoveSpeed( data );
				DrawOnInspectorObjectMoveIsOverDistance( data );
				DrawOnInspectorObjectMoveIsSyncRotation( data );
				DrawOnInspectorObjectMoveInitFuncName( data );
			});
		});
	}
	private void DrawOnInspectorObjectMoveRandomRect( A_ObjectMove.Data data )
	{
		Enclose( "Random Rect", () =>
		{
			Vertical( () =>
			{
				DrawOnInspectorObjectMoveRect( data, "Range" );
				DrawOnInspectorObjectMoveSpeed( data );
				DrawOnInspectorObjectMoveDelayFrame( data );
				DrawOnInspectorObjectMoveDurationFrame( data );
				DrawOnInspectorObjectMoveInitFuncName( data );
			});
		});
	}
#endregion //Draw OnInspector
#region      Multi Setting Inspector
	private void DrawInitialPositionMultiSetting()
	{
		var pos = EditorGUILayout.Vector3Field( "Initial Position", Target.initialPosition );
		if( Target.initialPosition != pos )
		{
			foreach( var t in targets )
			{
				var enemyCreator = t as EnemyCreator;
				enemyCreator.initialPosition = pos;
				SceneView.RepaintAll();
			}
		}	
	}
#endregion //Multi Setting Inspector
}
