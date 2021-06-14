using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public TransitionScript TS;
	public PlayerHealth PH;
	[SerializeField]
	bool unused = true;
	public string StageToLoad;

    void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.CompareTag("Player") && unused)
		{
			unused = false;
			
			TS.Transition(false, StageToLoad);
		}
    }
}
