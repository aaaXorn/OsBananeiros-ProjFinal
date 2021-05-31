using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPull : MonoBehaviour
{
	//onde o raycast começa, seu tamanho, a força do puxão do imã
	[SerializeField]
	float raycastStartPoint, raycastSize, pullForce;
	
	//informação do que o raycast acertou
	RaycastHit hitInfo;
	
    void FixedUpdate()
    {
		//para visualizar o raycast
		Debug.DrawLine(transform.position + (transform.forward * raycastStartPoint), transform.position + (transform.forward * raycastSize), Color.white);
		//gera o raycast
		Physics.Raycast(transform.position + (transform.forward * raycastStartPoint), transform.forward, out hitInfo, raycastSize);
		
		//para impedir erros
		if(hitInfo.collider != null)
		{
			//se o raycast acertar um pickup
			if(hitInfo.collider.tag == "Pickup")
			{
				//adiciona força para no objeto acertado pelo raycast na direção do imã
				hitInfo.collider.gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * pullForce, ForceMode.Impulse);
			}
		}
		
	}
}
