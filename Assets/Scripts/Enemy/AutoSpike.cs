using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpike : MonoBehaviour
{
	public GameObject Spike;
	
	//se o espinho foi ativado
	public bool activate;
	//timer e CD do espinho
	public float spikeTimer, maxTimer, spikeCD, maxCD;
	//velocidade do movimento do espinho
	public float speed;
	//direção do movimento do espinho
	public Vector3 Direction;
	
	
	//onde o raycast começa, seu tamanho
	[SerializeField]
	float raycastStartPoint, raycastSize;
	
	//informação do que o raycast acertou
	RaycastHit hitInfo;
	

    // Update is called once per frame
    void Update()
    {
        //para visualizar o raycast
		Debug.DrawLine(transform.position + (transform.forward * raycastStartPoint), transform.position + (transform.forward * raycastSize), Color.white);
		//gera o raycast
		Physics.Raycast(transform.position + (transform.forward * raycastStartPoint), transform.forward, out hitInfo, raycastSize);
		
		//para impedir erros
		if(hitInfo.collider != null)
		{
			//se o raycast acertar um pickup
			if(hitInfo.collider.tag == "Player")
			{
				activate = true;
			}
		}
		
		if(activate)
		{
			if(spikeTimer < maxTimer/2)
			{
				Spike.transform.Translate(Direction * speed * Time.deltaTime);
				
				spikeTimer += Time.deltaTime;
			}
			else if(spikeTimer >= maxTimer/2 && spikeTimer < maxTimer)
			{
				Spike.transform.Translate(Direction * -speed * Time.deltaTime);
				
				spikeTimer += Time.deltaTime;
			}
			
			if(spikeTimer >= maxTimer && spikeCD < maxCD)
				spikeCD += Time.deltaTime;
			else if(spikeCD >= maxCD)
			{
				spikeTimer = 0;
				spikeCD = 0;
				
				activate = false;
			}
		}
    }
}
