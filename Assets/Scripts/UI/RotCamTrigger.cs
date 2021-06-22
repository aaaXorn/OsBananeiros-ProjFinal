using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotCamTrigger : MonoBehaviour
{
	public TopDownCamera TDC;
	
	public float timer, spd, adjX;
	
    void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			TDC.RotateCamera(timer, spd, adjX);
			
			Destroy(gameObject);
		}
	}
}
