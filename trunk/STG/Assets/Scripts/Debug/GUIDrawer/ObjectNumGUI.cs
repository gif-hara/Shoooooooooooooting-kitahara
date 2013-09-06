/*===========================================================================*/
/*
*     * FileName    : ObjectNumGUI.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Text;


public class ObjectNumGUI : A_GUIElement
{
	private string[] header =
	{
		"EnemyShot\t\t",
		"Enemy\t\t\t\t",
		"PlayerShot\t\t",
		"Player\t\t\t\t",
		"Effect\t\t\t\t",
		"Total\t\t\t\t\t",
	};

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube( Vector3.zero, new Vector3( 800.0f, 600.0f, 0.0f ) );
	}
	
	public override void Draw ()
	{
		StringBuilder s = new StringBuilder();
		int i = 0;
		foreach( var h in header )
		{
			s.AppendFormat(
				h + "= {0}{1}",
				GetObjectCount( i++ ),
				System.Environment.NewLine
				);
		}
		Label( s.ToString() );
	}
	
	private int GetObjectCount( int i )
	{
		switch( i )
		{
		case 0:
			return ReferenceManager.refEnemyShotLayer.transform.childCount;
		case 1:
			return ReferenceManager.refEnemyLayer.transform.childCount;
		case 2:
			return ReferenceManager.refPlayerShotLayer.transform.childCount;
		case 3:
			return ReferenceManager.refPlayerLayer.transform.childCount;
		case 4:
			return ReferenceManager.refEffectLayer.transform.childCount;
		case 5:
			return
				ReferenceManager.refEnemyShotLayer.transform.childCount +
				ReferenceManager.refEnemyLayer.transform.childCount +
				ReferenceManager.refPlayerShotLayer.transform.childCount +
				ReferenceManager.refPlayerLayer.transform.childCount +
				ReferenceManager.refEffectLayer.transform.childCount;
		}
		
		return 0;
	}
}
