using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreTrigger : MonoBehaviour
{
	public SaveManager SM;
	
	public Pause pScript;
	public PauseMenu PM;
	public ItemGrab IG;
	
    public string lore, loreEN, lorePT;
	
	void Start()
	{
		switch (SM.GameLanguage)
		{
			case "English":
			lore = loreEN;
			break;
			
			case "Portugues":
			lore = lorePT;
			break;
			
			default:
			lore = loreEN;
			break;
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.CompareTag("Player") && IG.grabInput)
		{
			pScript.ClipboardPause();
			
			PM.ChangeLoreTxt(lore);
		}
	}
}
