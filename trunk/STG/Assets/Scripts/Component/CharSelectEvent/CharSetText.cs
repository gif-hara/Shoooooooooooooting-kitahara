/*===========================================================================*/
/*
*     * FileName    : CharSetText.cs
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
public class CharSetText : MonoBehaviour
{
	[SerializeField]
	private TextMesh refContent;

	void OnModifyChar( char c )
	{
		refContent.text = c.ToString();
	}
}
