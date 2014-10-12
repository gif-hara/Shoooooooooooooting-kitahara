/*===========================================================================*/
/*
*     * FileName    : SoundEntity.cs
*
*     * Description : .
*
*     * Author      : Hiroki_Kitahara.
*/
/*===========================================================================*/
using UnityEngine;
using System.Collections;


public class SoundEntity : MonoBehaviour
{
	private AudioSource refAudioSource;
	
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}
	
	public void Initialize( SoundManager.ClipData data )
	{
		refAudioSource = GetComponent<AudioSource>();
		refAudioSource.clip = data.clip;
		var soundManager = ReferenceManager.Instance.refSoundManager;
		refAudioSource.volume = data.volume * soundManager.masterVolume * soundManager.SEVolume;
	}
	
	public void Play()
	{
		refAudioSource.Play();
	}
	private void Destroy()
	{
		if( !refAudioSource.isPlaying )
		{
			Destroy( gameObject );
		}
	}
}
