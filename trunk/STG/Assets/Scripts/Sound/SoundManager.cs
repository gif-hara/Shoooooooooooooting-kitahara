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


public class SoundManager : A_Singleton<SoundManager>
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
	
	public float masterVolume;

	public float BGMVolume{ get{ return SaveLoad.Data.option.BGMVolume; } }

	public float SEVolume{ get{ return SaveLoad.Data.option.SEVolume; } }
	
	public List<ClipData> refClipList;
	
	[SerializeField]
	private AudioSource refBGMEntity;

	private Dictionary<string, ClipDictionaryData> clipDictionary = new Dictionary<string, ClipDictionaryData>();
	
	private List<SoundEntityData> entityDataList = new List<SoundEntityData>();

	private bool isPause = false;

	// Use this for initialization
	public override void Awake()
	{
		Instance = this;
		base.Awake();
		InitClipDictionary();
		InitEntityList();
		refBGMEntity.volume = BGMVolume * masterVolume;
	}

	public override void Update()
	{
		if( PauseManager.Instance.IsPause && !isPause )
		{
			isPause = true;
			refBGMEntity.Pause();
		}
		else if( !PauseManager.Instance.IsPause && isPause )
		{
			isPause = false;
			refBGMEntity.Play();
		}
	}

	public void Play( string label )
	{
		entityDataList[clipDictionary[label].Index].GetEntity().Play();
	}

	public void PlayBGM( string label )
	{
		refBGMEntity.volume = BGMVolume * masterVolume;
		refBGMEntity.clip = clipDictionary[label].ClipData.clip;
		refBGMEntity.Play();
	}

	public void FadeBGM( float volumeFrom, float volumeTo, int duration )
	{
		volumeFrom *= BGMVolume * masterVolume;
		volumeTo *= BGMVolume * masterVolume;
		StartCoroutine( FadeBGMCoroutine( volumeFrom, volumeTo, duration ) );
	}

	public void SetBGMVolume( float value )
	{
		refBGMEntity.volume = value * masterVolume;
	}

	public void SetSEVolume( float value )
	{
		Trans.AllVisit( t =>
		{
			var audioSource = t.GetComponent<AudioSource>();
			if( audioSource != null && audioSource != refBGMEntity )
			{
				audioSource.volume = value * masterVolume;
			}
		});
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

	private IEnumerator FadeBGMCoroutine( float volumeFrom, float volumeTo, int duration )
	{
		int currentDuration = 0;
		while( currentDuration <= duration )
		{
			refBGMEntity.volume = Mathf.Lerp( volumeFrom, volumeTo, currentDuration / (float)duration );

			if( !PauseManager.Instance.IsPause )
			{
				currentDuration++;
			}
			yield return new WaitForEndOfFrame();
		}

		refBGMEntity.volume = volumeTo;
	}
}
