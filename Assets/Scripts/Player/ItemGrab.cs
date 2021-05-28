using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
	public GameObject GrabbedItem;
	
	bool grabbing;//igual ao Input "Interact", pra poder usar no TriggerStay
	float grabTimer, grabCD = 1;//cooldown do grab, para evitar bugs

    void Update()
    {
		grabbing = Input.GetButton("Interact");
		
		if(grabTimer > 0)
		{
			grabTimer -= Time.deltaTime;
		}
		
        if(GrabbedItem)
		{
			//gruda o GrabbedItem nesse objeto
			GrabbedItem.transform.position = transform.position;
			GrabbedItem.transform.rotation = transform.rotation;
			
			if(grabTimer <= 0)
			{
				if(grabbing)
				{
					grabTimer = grabCD;
					
					//volta o GrabbedItem ao normal
					GrabbedItem.GetComponent<Rigidbody>().isKinematic = false;
					//desgruda o GrabbedItem desse objeto
					GrabbedItem = null;
				}
			}
		}
    }
	
	void OnTriggerStay(Collider other)
	{
		if(!GrabbedItem && grabTimer <= 0 && other.gameObject.CompareTag("Pickup"))
		{
			if(grabbing)
			{
				grabTimer = grabCD;
				
				//faz o objeto da colisão ser agarrado pelo jogador
				GrabbedItem = other.gameObject;
				GrabbedItem.GetComponent<Rigidbody>().isKinematic = true;
			}
		}
	}
}
