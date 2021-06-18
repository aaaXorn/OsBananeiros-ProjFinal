using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreTrigger : MonoBehaviour
{
	public Pause pScript;
	public PauseMenu PM;
	public ItemGrab IG;
	
    public string lore;
	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.CompareTag("Player") && IG.grabInput)
		{
			pScript.ClipboardPause();
			
			PM.ChangeLoreTxt(lore);
		}
	}
}
