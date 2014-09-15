/*===========================================================================*/
/*
*     * FileName    : ShadowMaterialCreateEditor.cs
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// .
/// </summary>
public class ShadowMaterialCreateEditor : A_EditorWindowBase
{
	/// <summary>
	/// 実体.
	/// </summary>
	private static ShadowMaterialCreateEditor Instance
	{
		get
		{
			return instance ?? (instance = EditorWindow.GetWindow<ShadowMaterialCreateEditor>());
		}
	}
	private static ShadowMaterialCreateEditor instance;

	[SerializeField]
	private List<Material> refMaterials = new List<Material>();

	private Vector2 scrollPosition = Vector2.zero;

	/// <summary>
	/// ウィンドウの生成.
	/// </summary>
	[MenuItem( "Window/ShadowMaterialCreate" )]
	private static void CreateWindow()
	{
		instance = EditorWindow.GetWindow<ShadowMaterialCreateEditor>();
		instance.title = "ShadowMaterialCreate";
	}

	void OnGUI()
	{
		if( refMaterials.FindIndex( m => m == null ) == -1 )
		{
			refMaterials.Add( null );
		}

		scrollPosition = EditorGUILayout.BeginScrollView( scrollPosition );

		Vertical( () =>
		{
			for( int i=0,imax=refMaterials.Count; i<imax; i++ )
			{
				refMaterials[i] = EditorGUILayout.ObjectField( refMaterials[i], typeof( Material ), false ) as Material;
			}
		});

		var selections = Selection.objects;
		if( selections.Length >= 1 )
		{
			Button( "Add Selection", () =>
			{
				for( int i=0; i<selections.Length; i++ )
				{
					var obj = selections[i];
					if( obj.GetType() != typeof( Material ) )
					{
						continue;
					}

					if( refMaterials.Find( m => m == obj ) )
					{
						continue;
					}

					refMaterials.RemoveAll( m => m == null );
					refMaterials.Add( obj as Material );
				}
			});
		}

		if( refMaterials.Count > 0 )
		{
			Button( "Create Shadow Material", () =>
			{
				for( int i=0,imax=refMaterials.Count; i<imax; i++ )
				{
					var originalMaterial = refMaterials[i];
					if( originalMaterial == null )
					{
						continue;
					}

					var shadowMaterial = AssetDatabase.LoadAllAssetsAtPath( "Assets/DataSources/Material/" + originalMaterial.name + "Shadow.mat" );
					if( shadowMaterial.Length <= 0 )
					{
						Material material = new Material( Shader.Find( "Custom/Vertex Color And Texture" ) );
						material.name = originalMaterial.name + "Shadow";
						material.mainTexture = originalMaterial.mainTexture;
						material.SetColor( "_Color", Color.black );
						AssetDatabase.CreateAsset( material, "Assets/DataSources/Material/" + material.name + ".mat" );
						AssetDatabase.Refresh();
						AssetDatabase.SaveAssets();
					}
				}
			});
		}

		EditorGUILayout.EndScrollView();
	}
}
