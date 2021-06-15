using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Button : MonoBehaviour
{
	public StopSpin SS;
	
	public bool pressed;
	
    void OnCollisionEnter(Collision other)
	{
		if(!pressed && other.gameObject.CompareTag("Player"))
		{
			SS.ButtonPressed();
			
			pressed = true;
		}
	}
}
