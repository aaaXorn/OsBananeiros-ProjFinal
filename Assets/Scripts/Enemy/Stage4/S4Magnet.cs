using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4Magnet : MonoBehaviour
{
    //onde o raycast começa, seu tamanho, velocidade do puxão do imã
	[SerializeField]
	float raycastStartPoint, raycastSize, pullSpd;
	
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
			if(hitInfo.collider.tag == "Barrel")
			{
				//adiciona velocidade para no objeto acertado pelo raycast
				hitInfo.collider.gameObject.GetComponent<PlayerBarrel>().speed = pullSpd;
			}
		}
	}
}
