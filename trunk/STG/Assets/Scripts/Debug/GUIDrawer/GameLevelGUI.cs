/*===========================================================================*/
/*
*     * FileName    : GameLevelGUI.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class GameLevelGUI : A_GUIElement
{
	public override void Draw ()
	{
		Label( "Game Level" );
		float gameLevel = (float)GameManager.gameLevel;
		Horizontal( () =>
		{
			gameLevel = GUILayout.HorizontalSlider( gameLevel, 0.0f, 100.0f, GUILayout.Width( 150.0f ) );
			Label( gameLevel.ToString() );
		});
		Horizontal( () =>
		{
			Label( "Game Level Experience = " + ReferenceManager.GameManager.GameLevelExperience );
		});
		Horizontal( () =>
		{
			Label( "Collision EnemyShot = " + ReferenceManager.GameManager.CollisionEnemyShot );
		});
		GameManager.gameLevel = (int)gameLevel;
	}
}
