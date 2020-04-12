using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour {

	private ChapterText chapterScreen;

	private GameListener listener;

	void Start()
	{
		this.chapterScreen = this.GetComponent<ChapterText> ();
		this.listener = this.GetComponent<GameListener> ();
	}

	void Update () 
	{
		if (listener.Listen ()) 
		{
			this.chapterScreen.Show ();
		}
	}
}
