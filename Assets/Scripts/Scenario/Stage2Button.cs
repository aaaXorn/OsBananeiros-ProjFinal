using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Button : MonoBehaviour
{
	public StopSpin SS;
	
	public AudioSource audioS;
	
	public bool pressed;
	
    void OnCollisionEnter(Collision other)
	{
		if(!pressed && other.gameObject.CompareTag("Player"))
		{
			audioS.Play();
			
			SS.ButtonPressed();
			
			pressed = true;
		}
	}
}
