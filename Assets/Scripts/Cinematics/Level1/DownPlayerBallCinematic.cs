using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlayerBallCinematic : MonoBehaviour {

	public Transform player;
	public float downVelocity = 0.5f;
	public FadeText text;
	public Animator whiteScreeen;
	public GameObject ball;


	private bool showIntroScreen = true;
	private bool hideIntroScreen = false;
	private bool endCinematic = false;
	private bool waitASecond = false;

	void Start () {
		text.SetFadeIn (true);
	}
		
	// Update is called once per frame
	void Update () {
		this.player.position = new Vector2 (this.player.position.x, Mathf.Max(this.player.position.y - this.downVelocity,-1f));
		if (showIntroScreen)
		{
			StartCoroutine(text.FadeTextToFullAlpha ());
			showIntroScreen = text.IsFadeIn ();
		}
		else if(this.player.position.y < 3)
		{
			if (!text.IsFadeIn ())
			{
				StartCoroutine (text.FadeTextToZeroAlpha ());
			} 
			else 
			{
				this.whiteScreeen.SetBool ("isShowed", !endCinematic);
				this.endCinematic = true;
				if (this.waitASecond) 
				{
					Destroy (ball);
					this.player.gameObject.SetActive (true);
					Destroy (this);
				}
				else 
				{
					StartCoroutine (WaitASecond ());
				}

			}
		}
	}

	IEnumerator WaitASecond()
	{
		yield return new WaitForSeconds (1);
		this.waitASecond = true;
	}

}
