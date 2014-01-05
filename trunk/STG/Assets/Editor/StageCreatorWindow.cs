//================================================
/*!
    @file   StageCreatorWindow.cs

    @brief  ステージ作成ウィンドウクラス.

    @author CyberConnect2 Co.,Ltd.  Hiroki_Kitahara.
*/
//================================================
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// ステージ作成ウィンドウクラス.
/// </summary>
using System;


public class StageCreatorWindow : A_EditorWindowBase
{
	/// <summary>
	/// 実体.
	/// </summary>
	private static StageCreatorWindow Instance
	{
		get
		{
			return instance ?? (instance = EditorWindow.GetWindow<StageCreatorWindow>());
		}
	}
	private static StageCreatorWindow instance;

	/// <summary>
	/// タイムラインズーム値.
	/// </summary>
	[SerializeField]
	private float zoom;
	
	/// <summary>
	/// アクショナブルオブジェクトボタン描画時の座標補正用のディクショナリ.
	/// </summary>
	private Dictionary<int, int> actionableObjectDictionary;

	/// <summary>
	/// 左側メニューの幅.
	/// </summary>
	private const int LeftMenuWidthNum = 210;

	/// <summary>
	/// メニューとタイムラインのボーダーラインの色.
	/// </summary>
	private static Color BoarderLineColor = new Color( 45.0f/255.0f, 45.0f/255.0f, 45.0f/255.0f,1.0f );

	/// <summary>
	/// タイムラインの背景色
	/// </summary>
	private static Color TimeLineBackgroundColor = new Color( 30.0f/255.0f, 30.0f/255.0f, 30.0f/255.0f,1.0f );

	/// <summary>
	/// ステージ管理者.
	/// </summary>
	/// <value>The manager.</value>
	private StageManager StageManager
	{
		get
		{
			if( stageManager == null )
			{
				var obj = GameObject.FindWithTag( "Stage" );
				if( obj == null )
				{
					return null;
				}

				stageManager = obj.GetComponent<StageManager>();
			}

			return stageManager;
		}
	}
	private StageManager stageManager;

	private GameManager GameManager
	{
		get
		{
			if( gameManager == null )
			{
				var obj = GameObject.Find( "GameManager" );
				if( obj == null )
				{
					return null;
				}
				
				gameManager = obj.GetComponent<GameManager>();
			}
			
			return gameManager;
		}
	}
	private GameManager gameManager;

	private GUIDrawer GUIDrawer
	{
		get
		{
			if( guiDrawer == null )
			{
				var obj = GameObject.Find( "GUIDrawer" );
				if( obj == null )
				{
					return null;
				}
				
				guiDrawer = obj.GetComponent<GUIDrawer>();
			}
			
			return guiDrawer;
		}
	}
	private GUIDrawer guiDrawer;

	/// <summary>
	/// ウィンドウの生成.
	/// </summary>
	[MenuItem( "Window/StageCreator" )]
	private static void CreateWindow()
	{
		instance = EditorWindow.GetWindow<StageCreatorWindow>();
		instance.title = "StageCreate";
	}

	void Update()
	{
		if( Application.isPlaying )
		{
			Instance.Repaint();
		}
	}

	/// <summary>
	/// GUIの描画.
	/// </summary>
	void OnGUI()
	{
		if( !CanCreate )	return;

		var pos = UpdateWindowPosition();

		Vertical( () =>
		{
			OnGUISystem();
			OnGUIActionablePrefabCreateButton();
		});

		DrawTimeLine();
		DrawActionableObject();
		// 現在のタイムラインの描画.
		DrawTimeLine( (int)pos.height / 2, StageManager.timeLineManager.TimeLine.ToString(), Color.red, FixedZoom );
	}
	private Rect UpdateWindowPosition()
	{
		var pos = Instance.position;
//		pos.width = 400.0f;
//		instance.position = new Rect(
//			pos.x,
//			pos.y,
//			400,
//			pos.height
//			);

		return pos;
	}
	/// <summary>
	/// タイムラインの描画
	/// </summary>
	private void DrawTimeLine()
	{
		var pos = Instance.position;

		// 背景の描画.
		EditorGUI.DrawRect( new Rect( LeftMenuWidthNum + 10, 0, 2, pos.height ), BoarderLineColor );
		EditorGUI.DrawRect( new Rect( LeftMenuWidthNum + 12, 0, 900, pos.height ), TimeLineBackgroundColor );

		int currentTimeLine = 0;
		int interval = ((int)zoom <= 1 ) ? 100 : 100 - ((int)(FixedZoom * 5.0f) * 5);
		interval = interval <= 5 ? 5 : interval;

		while( pos.height > currentTimeLine )
		{
			int sub = interval - ( (StageManager.timeLineManager.TimeLine - ((int)pos.height / 2) + currentTimeLine) % interval);
			currentTimeLine += sub;
			int timeLine = (currentTimeLine + StageManager.timeLineManager.TimeLine) - ((int)pos.height / 2);
			if( timeLine >= 0 )
			{
				DrawTimeLine( (int)pos.height - currentTimeLine, timeLine.ToString(), Color.white, FixedZoom );
			}
			
			currentTimeLine += 1;
		}
	}

	private void DrawTimeLine( int y, string label, Color color, float rate )
	{
		var pos = Instance.position;
		float fixedY = (y - (pos.height / 2) ) * rate;
		y += (int)fixedY;
		if( y >= pos.height || y < 0 )	return;
		
		EditorGUI.LabelField( new Rect( pos.width - label.Length * 9, -16 + y, pos.width, 20 ), label );
		EditorGUI.DrawRect( new Rect( LeftMenuWidthNum + 12, y, pos.width, 1 ), color );
	}

	private void DrawActionableObject()
	{
		int timeLine = StageManager.timeLineManager.TimeLine;
		var pos = Instance.position;
		int min = timeLine - (int)pos.height / 2;
		int max = timeLine + (int)pos.height / 2;
		actionableObjectDictionary = new Dictionary<int, int>();

		for( int i=0,imax=StageManager.Trans.childCount; i<imax; i++ )
		{
			var actionableObject = StageManager.Trans.GetChild( i ).GetComponent<A_StageTimeLineActionable>();
			if( actionableObject == null )	continue;

			if( actionableObject.timeLine > min && actionableObject.timeLine < max )
			{
				int currentTimeLine = timeLine - actionableObject.timeLine;
				bool isDestroy = DrawActionableButton( currentTimeLine + (int)pos.height / 2, actionableObject, FixedZoom );
				if( isDestroy )
				{
					return;
				}
			}
		}
	}
	private bool DrawActionableButton( int y, A_StageTimeLineActionable actionableObject, float rate )
	{
		var label = actionableObject.name;
		label = label.Remove( label.IndexOf( "[" ), label.IndexOf( "]" ) + 1 );
		var pos = Instance.position;
		float fixedY = (y - (pos.height / 2) ) * rate;
		y += (int)fixedY;
		if( y >= pos.height || y < 0 )	return false;
		
		if( !actionableObjectDictionary.ContainsKey( y ) )
		{
			actionableObjectDictionary.Add( y, 1 );
		}
		
		int actionableButtonWidth = label.Length * 9;
		int buttonY = (-20 * actionableObjectDictionary[y]) + y;
		if( GUI.Button( new Rect( LeftMenuWidthNum + 12, buttonY, actionableButtonWidth, 20 ), label ) )
		{
			Selection.activeGameObject = actionableObject.gameObject;
		}
		if( GUI.Button( new Rect( LeftMenuWidthNum + 12 + actionableButtonWidth, buttonY, 20, 20 ), "T" ) )
		{
			StageManager.timeLineManager.TimeLine = actionableObject.timeLine;
			Selection.activeGameObject = actionableObject.gameObject;
		}
		if( GUI.Button( new Rect( LeftMenuWidthNum + 12 + actionableButtonWidth + 20, buttonY, 20, 20 ), "C" ) )
		{
			var copy = Instantiate( actionableObject ) as GameObject;
			copy.transform.parent = StageManager.transform;
		}
		if( GUI.Button( new Rect( LeftMenuWidthNum + 12 + actionableButtonWidth + 20 + 20, buttonY, 20, 20 ), "D" ) )
		{
			DestroyImmediate( actionableObject.gameObject );
			return true;
		}

		DrawTimeLine( y, actionableObject.timeLine.ToString(), Color.yellow, 0.0f );
		
		actionableObjectDictionary[y]++;

		return false;
	}
	private void OnGUISystem()
	{
		Enclose( "System", () =>
		{
			StageManager.timeLineManager.TimeLine = IntField( "Time Line", StageManager.timeLineManager.TimeLine, LeftMenuWidth );
			zoom = FloatField( "Zoom", zoom, 1.0f, 100.0f, LeftMenuWidth );
			GameManager.GameLevel = IntField( "Game Level", GameManager.GameLevel, LeftMenuWidth );
			GameManager.playerId = IntField( "Player Id", GameManager.playerId, LeftMenuWidth );
			GUIDrawer.IsDraw = EditorGUILayout.Toggle( "Debug Draw", GUIDrawer.IsDraw, LeftMenuWidth );
		});
	}
	private void OnGUIActionablePrefabCreateButton()
	{
		Enclose( "Actionable Prefab", () =>
		{
			for( int i=0,imax=StageManager.prefabActionableObjectList.Count; i<imax; i++ )
			{
				DrawActionablePrefabCreateButton( StageManager.prefabActionableObjectList[i].gameObject, (a) => a.Initialize( StageManager.timeLineManager.TimeLine ) );
			}
		});
	}
	/// <summary>
	/// A_StageTimeLineActionableオブジェクトの生成ボタンの描画と初期化.
	/// </summary>
	/// <param name='prefab'>
	/// Prefab.
	/// </param>
	/// <param name='initialFunc'>
	/// Initial func.
	/// </param>
	private void DrawActionablePrefabCreateButton( GameObject prefab, System.Action<A_StageTimeLineActionable> initialFunc )
	{
		Button( prefab.name, () =>
		{
			// オブジェクトの生成.
			var obj = Instantiate( prefab ) as GameObject;
			obj.transform.parent = StageManager.transform;
			
			// Actionableオブジェクトの初期化.
			var actionable = obj.GetComponent<A_StageTimeLineActionable>();
			actionable.Initialize( StageManager.timeLineManager.TimeLine );
			
			// あとは各々で初期化が必要な場合は処理をする.
			initialFunc( actionable );
			
			// 生成したゲームオブジェクトをInspectorに表示する.
			Selection.activeGameObject = obj;
		}, LeftMenuWidth);
	}
	/// <summary>
	/// ステージ作成が可能であるか？.
	/// </summary>
	/// <value><c>true</c> if this instance can create; otherwise, <c>false</c>.</value>
	private bool CanCreate
	{
		get
		{
			return StageManager != null;
		}
	}
	/// <summary>
	/// 左側のメニューの幅を返す.
	/// </summary>
	/// <value>The width of the left menu.</value>
	private GUILayoutOption LeftMenuWidth
	{
		get
		{
			return Width( LeftMenuWidthNum );
		}
	}
	private float FixedZoom
	{
		get
		{
			return (zoom - 1.0f) * 0.1f;
		}
	}
}
