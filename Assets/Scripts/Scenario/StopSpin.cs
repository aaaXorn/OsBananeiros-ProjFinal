using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSpin : MonoBehaviour
{
	public SaveManager SM;
	public Stage2Button S2B;
	public GameObject Ratoelho;
	
    public int presses;
	
	void Start()
	{
		//se o jogador tiver pego o checkpoint, faz ele começar mais avançado
		if(SM.S2Checkpoint)
		{
			presses++;
			S2B.pressed = true;
			
			Ratoelho.transform.position = new Vector3(-4.77f, 0.93f, -41.75f);
		}
	}
	
	public void ButtonPressed()
	{
		presses++;
		
		if(presses == 1)
			SM.S2Checkpoint = true;
		
		if(presses >= 2)
		{
			gameObject.BroadcastMessage("DeactivateScript", SendMessageOptions.RequireReceiver);
			gameObject.BroadcastMessage("ChangeRotation", 0, SendMessageOptions.RequireReceiver);
		}
	}
}
