using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeText : MonoBehaviour 
{

	public float time = 5f;

	private TextMeshPro tmp;
	private bool fadeIn = false;

	void Start ()
	{
		tmp = this.GetComponent<TextMeshPro> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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
	}

	public bool IsFadeIn()
	{
		return this.fadeIn;
	}

	public void SetFadeIn(bool fade)
	{
		this.fadeIn = fade;
	}
}
