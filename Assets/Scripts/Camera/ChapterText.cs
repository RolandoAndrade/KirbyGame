using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterText : MonoBehaviour {


	private FadeText fadeAction;
	private SpriteRenderer spriteRenderer;
	private const float TIME = 1f;
	private bool isShowed = false;
	private bool isWhite = false;
	private bool isEnded = false;

	void Start () 
	{
		this.spriteRenderer = this.GetComponent<SpriteRenderer> ();
		this.fadeAction = this.transform.Find ("Text").gameObject.GetComponent<FadeText> ();
	}
		
	void Update () 
	{
		if (this.isShowed) 
		{
			
			if (this.isWhite)
			{
				if (fadeAction.IsFadeIn ()) 
				{
					StartCoroutine (this.fadeAction.FadeTextToFullAlpha ());
				} 
				else 
				{
					this.isEnded = true;
				}
			}
			else
			{
				StartCoroutine (FadeToFullAlpha ());
			}
		}
	}

	public bool Show()
	{
		this.isShowed = true;
		return !this.isEnded;
	}

	public IEnumerator FadeToFullAlpha()
	{
		this.spriteRenderer.color = new Color (spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,0);
		while (spriteRenderer.color.a < 1.0f) 
		{
			spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g,
				spriteRenderer.color.b, spriteRenderer.color.a + Time.deltaTime/TIME);
			yield return null;
		}
		this.isWhite = true;
		StartCoroutine (this.fadeAction.FadeTextToFullAlpha());
	}
}
