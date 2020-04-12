using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;

public class Captions : MonoBehaviour 
{
	public List<string> captions = new List<string>();

	private FadeText fadeAction;
	private TextMeshPro tmp;


	private int index = 0;
	private bool isLooped = false;
	private bool isEnded = false;


	void Start () 
	{
		tmp = this.GetComponent<TextMeshPro> ();
		fadeAction = this.GetComponent<FadeText> ();
		tmp.text = captions [0];

	}
		

	void Update ()
	{
		if (!this.isEnded)
		{
			if (this.fadeAction.IsFadeIn () && !this.isLooped) 
			{
				this.isLooped = true;
				this.Next ();
			}
			else if (this.fadeAction.IsFadeIn()) 
			{
				StartCoroutine (fadeAction.FadeTextToFullAlpha ());
			}
			else if (Input.anyKeyDown) 
			{
				this.isLooped = false;
				StartCoroutine (fadeAction.FadeTextToZeroAlpha());
			}
		}
	}

	void Next()
	{
		try
		{
			tmp.text = captions [++index];
		}
		catch
		{
			this.isEnded = true;
		}
	}

	public bool IsEnded()
	{
		return this.isEnded;
	}
}
