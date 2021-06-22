using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
	public SaveManager SM;
	
    public TransitionScript TS;
	[SerializeField]
	bool unused = true;
	public string StageToLoad;

    void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.CompareTag("Player") && unused)
		{
			unused = false;
			
			SM.CurrentStage = StageToLoad;
			TS.Transition(false, StageToLoad);
		}
    }
}
