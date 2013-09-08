/*===========================================================================*/
/*
*     * FileName    : SoundManager.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SoundManager : GameMonoBehaviour
{
	[System.Serializable]
	public class ClipData
	{
		public AudioClip clip;
		
		public int maxPlayNum;
		
		public float volume;
	}
	
	public class ClipDictionaryData
	{
		public ClipData ClipData{ get{ return clipData; } }
		private ClipData clipData;
		
		public int Index{ get{ return index; } }
		private int index;
		
		public ClipDictionaryData( ClipData clipData, int index )
		{
			this.clipData = clipData;
			this.index = index;
		}
	}
	
	public class SoundEntityData
	{
		private List<SoundEntity> entityList;
		
		private int playCount;
		
		private SoundManager owner;
		
		private ClipData clipData;
		
		public SoundEntityData( SoundManager owner, ClipData clipData )
		{
			this.entityList = new List<SoundEntity>();
			playCount = 0;
			this.owner = owner;
			this.clipData = clipData;
		}
		
		public SoundEntity GetEntity()
		{
			int index = playCount % clipData.maxPlayNum;
			playCount++;
			if( index >= entityList.Count )
			{
				var entity = (GameObject.Instantiate( owner.prefabSoundEntity ) as GameObject).GetComponent<SoundEntity>();
				entity.gameObject.name = string.Format( "[SND] {0}[{1}]", clipData.clip.name, index );
				entity.Initialize( clipData );
				entity.transform.parent = owner.transform;
				entityList.Add( entity );
				
				return entity;
			}
			else
			{
				return entityList[index];
			}
		}
	}
	
	public GameObject prefabSoundEntity;
	
	public List<ClipData> refClipList;
	
	private Dictionary<string, ClipDictionaryData> clipDictionary = new Dictionary<string, ClipDictionaryData>();
	
	private List<SoundEntityData> entityDataList = new List<SoundEntityData>();
	
	// Use this for initialization
	public override void Awake()
	{
		base.Awake();
		InitClipDictionary();
		InitEntityList();
	}

	public void Play( string label )
	{
		entityDataList[clipDictionary[label].Index].GetEntity().Play();
	}
	
	private void InitClipDictionary()
	{
		int i = 0;
		refClipList.ForEach( (obj) =>
		{
			clipDictionary.Add( obj.clip.name, new ClipDictionaryData( obj, i++ ) );
		});
	}
	
	private void InitEntityList()
	{
		for( int i=0,imax=refClipList.Count; i<imax; i++ )
		{
			entityDataList.Add( new SoundEntityData( this, refClipList[i] ) );
		}
	}
}
