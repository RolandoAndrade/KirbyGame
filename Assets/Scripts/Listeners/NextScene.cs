using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene:MonoBehaviour {

	public int nextLevel;

	public void ChangeScene()
	{
		SceneManager.LoadScene (this.nextLevel);
	}

}