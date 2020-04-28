using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClass : MonoBehaviour
{
	public float fadeTime = 1f;
	private AudioSource[] traks;
	private int trak = 0;
	private bool changeTrak = false;

	private void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
		this.traks = this.GetComponents<AudioSource> ();
		Debug.Log (traks.Length);
	}

	void Update()
	{
	}

	public void PlayMusic()
	{
		if (traks[trak].isPlaying) return;
		traks[trak].Play();
	}

	public void StopMusic()
	{
		traks[trak].Stop();
	}

	public void ChangeTrack()
	{
		if (!this.changeTrak)
		{
			this.changeTrak = true;
			StartCoroutine (FadeMusic ());
		}

	}

	IEnumerator FadeMusic()
	{
		if (!traks [trak + 1].isPlaying)
			traks [trak + 1].Play ();
		while (traks[trak].volume > 0) 
		{
			traks [trak].volume -= Time.deltaTime / fadeTime;
			traks [trak + 1].volume += Time.deltaTime / fadeTime;
			yield return null;
		}
		traks [trak].Stop ();
		this.trak++;
		this.changeTrak = false;

	}
}