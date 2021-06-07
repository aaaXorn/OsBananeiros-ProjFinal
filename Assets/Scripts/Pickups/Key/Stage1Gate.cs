using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Gate : MonoBehaviour
{
	bool open;
	
    void GateOpen()
	{
		if(!open)
		{
			//arruma a posição da porta
			transform.Rotate(0, 0, 90);
			transform.Translate(1.3f, -0.9f, 0, Space.Self);
			
			//impede GateOpen() de acontecer mais uma vez
			open = true;
		}
	}
}
