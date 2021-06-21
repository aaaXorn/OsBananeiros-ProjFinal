using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodaCompartScript : MonoBehaviour
{
	public GameObject MagnetPrefab;
	
	public AudioSource audioS;
	public AudioClip openSFX;
	
	public bool open;
	
	void Screwdriver()
	{
		if(!open)
		{
			//faz o sfx
			audioS.PlayOneShot(openSFX);
			
			Instantiate(MagnetPrefab, transform.position + new Vector3(0, 0, 2), transform.rotation);
			
			open = true;
		}
	}
}
