/*===========================================================================*/
/*
*     * FileName    : WindowStyleTextSetter.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;

/// <summary>
/// .
/// </summary>
public class WindowStyleTextSetter : MonoBehaviour
{
	[SerializeField]
	private TextMesh refTextMesh;

	private const string WindowName = "Window";

	private const string FullScreenName = "FullScreen";

	void Start()
	{
		OnModifiedWindowStyle();
	}

	void OnModifiedWindowStyle()
	{
		refTextMesh.text = OptionData.Settings.WindowStyle == GameDefine.WindowStyle.Window
			? WindowName
			: FullScreenName;
		Debug.Log("refTextMesh.text = " + refTextMesh.text);
	}
}
