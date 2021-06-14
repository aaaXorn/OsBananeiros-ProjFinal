using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Gate : MonoBehaviour
{
	public SaveManager SM;
	
	public GameObject Ratoelho, Key;
	
	bool open;
	
	void Start()
	{
		//se o jogador tiver pego o checkpoint, faz ele começar mais avançado
		if(SM.S1Checkpoint)
		{
			GateOpen();
			Ratoelho.transform.position = new Vector3(-18.57f, 25.91f, -62.25f);
			Destroy(Key);
		}
	}
	
    void GateOpen()
	{
		if(!open)
		{
			//arruma a posição da porta
			transform.Rotate(0, 0, 90);
			transform.Translate(1.3f, -0.9f, 0, Space.Self);
			
			//setta o checkpoint do primeiro stage
			SM.S1Checkpoint = true;
			
			//impede GateOpen() de acontecer mais uma vez
			open = true;
		}
	}
}
