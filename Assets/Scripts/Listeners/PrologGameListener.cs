using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologGameListener : MonoBehaviour, GameListener 
{
	public MusicClass music;
	public Captions captions;
	private bool played = false;

	public bool Listen ()
	{
		if (captions.IsEnded ()&&!played)
		{
			played = true;
			music.ChangeTrack ();
		}
		return captions.IsEnded ();
	}
}
