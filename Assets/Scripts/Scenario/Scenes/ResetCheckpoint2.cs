using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCheckpoint2 : MonoBehaviour
{
	public SaveManager SM;

    void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
			SM.S2Checkpoint = false;
	}
}
