using UnityEngine;
using System.Collections;

public class CameraController_m : MonoBehaviour 
{
	public Transform Player;
	public float m_speed = 0.1f;
	public void Start()
	{

	}

	public void Update()
	{


		if (Player) 
		{
		
			transform.position = Vector3.Lerp(transform.position, Player.position, m_speed) + new Vector3(0, 0, -12);
		}


	}
}
