using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3Checkpoints : MonoBehaviour
{
	public SaveManager SM;
	
	public float checkpNo;
	
	void Start()
	{
		//se esse checkpoint já tiver sido pego)
		if(SM.S3Checkpoints >= checkpNo)
			Destroy(gameObject);
	}
	
    void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			SM.S3Checkpoints++;
			
			Destroy(gameObject);
		}
	}
}
