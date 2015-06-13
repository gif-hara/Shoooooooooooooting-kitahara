using UnityEngine;
using UnityEditor;
using System.Collections;

public class ARMModificationProcessor : UnityEditor.AssetModificationProcessor {

	static void OnWillSaveAssets (string[] paths)
	{
		foreach(string path in paths){
			ARMModificationManager.Modify(path);
		}
	}
}
