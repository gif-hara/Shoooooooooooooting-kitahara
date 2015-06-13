using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ARMCacheData {

	public string refGUID;
	public int instanceID;
	//	public string componentName;
	public int propertyCount;

	public ARMCacheData (string refGUID, int instanceID, int propertyCount) {
		this.refGUID = refGUID;
		this.instanceID = instanceID;
		this.propertyCount = propertyCount;
	}
}

[System.Serializable]
public class ARMReferenceTable : Serialize.TableBase<string, List<ARMCacheData>, ARMReferencePair> {

}

[System.Serializable]
public class ARMReferencePair : Serialize.KeyAndValue<string, List<ARMCacheData>> {

}

