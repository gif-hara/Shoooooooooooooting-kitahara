/*===========================================================================*/
/*
*     * FileName    : Random.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

//#define OUTPUT_LOG

#if UNITY_EDITOR
/// <summary>
/// .
/// </summary>
public class Random : MonoBehaviour
{
	private static int useCount = 0;

	public static int Range( int min, int max )
	{
		UpdateUseCount();
		return UnityEngine.Random.Range( min, max );
	}

	public static float Range( float min, float max )
	{
		UpdateUseCount();
		return UnityEngine.Random.Range( min, max );
	}

	public static int seed
	{
		set
		{
			UnityEngine.Random.seed = value;
		}
		get
		{
			return UnityEngine.Random.seed;
		}
	}

	public static Vector2 insideUnitCircle
	{
		get
		{
			UpdateUseCount();
			return UnityEngine.Random.insideUnitCircle;
		}
	}

	public static float value
	{
		get
		{
			UpdateUseCount();
			return UnityEngine.Random.value;
		}
	}

	private static void UpdateUseCount()
	{
#if OUTPUT_LOG
		useCount++;

		if( ReferenceManager.Instance != null )
		{
			Debug.Log( "Update Frame = " + ReferenceManager.Instance.FrameCountRecorder.CurrentFrameCount + " useCount = " + useCount );
		}
		else
		{
			Debug.Log( "Update useCount = " + useCount );
		}
#endif
	}
}
#endif
