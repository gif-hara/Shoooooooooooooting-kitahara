using UnityEngine;
using UnityEditor;
using System.Collections;

public class ARMImportProcessor : AssetPostprocessor {

	static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromPath)
	{
		foreach(string path in importedAssets){
			ARMModificationManager.Modify(path);
		}
		foreach(string path in deletedAssets){
			ARMModificationManager.Delete(path);
		}
	}
}
