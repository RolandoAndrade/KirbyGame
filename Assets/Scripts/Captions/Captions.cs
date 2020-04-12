using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;

public class Captions : MonoBehaviour 
{
	public List<string> captions = new List<string>();
	public float time = 10f;

	private TextMeshPro tmp;

	private bool fadeIn = false;
	private int index = 0;
	private bool isEnded = false;


	void Start () 
	{
		tmp = this.GetComponent<TextMeshPro> ();
		tmp.text = captions [0];

	}
		

	void Update ()
	{
		if (!this.isEnded)
		{
			if (fadeIn) 
			{
				StartCoroutine (FadeTextToFullAlpha ());
			}
			if (Input.anyKeyDown) 
			{

				StartCoroutine (FadeTextToZeroAlpha());
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


	public IEnumerator FadeTextToFullAlpha()
	{
		this.tmp.color = new Color (tmp.color.r,tmp.color.g,tmp.color.b,0);
		while (tmp.color.a < 1.0f) 
		{
			tmp.color = new Color (tmp.color.r, tmp.color.g,
				tmp.color.b, tmp.color.a + Time.deltaTime/time);
			yield return null;
		}
		this.fadeIn = false;
	}

	public IEnumerator FadeTextToZeroAlpha()
	{
		this.tmp.color = new Color (tmp.color.r,tmp.color.g,tmp.color.b,1);
		while (tmp.color.a > 0.0f) 
		{
			tmp.color = new Color (tmp.color.r, tmp.color.g,
				tmp.color.b, tmp.color.a - Time.deltaTime/time);
			yield return null;
		}
		this.fadeIn = true;
		this.Next ();
	}

	public void IsEnded()
	{
		return this.isEnded;
	}
}
