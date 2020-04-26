using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public int nextLevel;

	private const float SECONDS_TO_CHANGE_SCENE = 1f;

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
			if (!this.chapterScreen.Show ())
			{
				StartCoroutine (this.ChangeScene ());
			}

		}
	}

	IEnumerator ChangeScene()
	{
		yield return new WaitForSeconds (SECONDS_TO_CHANGE_SCENE);
		SceneManager.LoadScene (this.nextLevel);
	}
}
