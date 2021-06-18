using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3Chase : MonoBehaviour
{
	[SerializeField]
	GameObject Player;
	[SerializeField]
	PlayerHealth PH;
	
	//se o objeto já pode se mover ou se ele deve parar
	public bool start, stop;
	//velocidade
	public float speed;
	//atrasa o começo do movimento
	public float moveDelay;
	//direção
	public Vector3 Direction;
	
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
		PH = Player.GetComponent<PlayerHealth>();
    }
	
    void FixedUpdate()
    {
		//move o objeto
        if(start && !stop)
		{
			if(moveDelay <= 0)
				transform.Translate(Direction * speed * Time.deltaTime, Space.Self);
			else
				moveDelay -= Time.deltaTime;
		}
    }
	
	void OnTriggerEnter(Collider other)
    {
		//se a colisão for do collider principal do player (e não o de grab)
		if(other.gameObject.CompareTag("Player") && other != PH.GrabCollider)
			//OHKO no player
			PH.TakeDamage(10, true, 0);
		
		//começa se tocar em outro objeto "Chase"
		if(other.gameObject.CompareTag("Chase") && !stop)
			start = true;
		//para se tocar em um objeto "StopChase"
		else if(other.gameObject.CompareTag("StopChase"))
		{
			start = false;
			stop = true;
		}
	}
}
