using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
	[SerializeField]
	GameObject Player;
	[SerializeField]
	PlayerHealth PH;
	
	//se o objeto é deletado quando colide
	public bool deleteOnHit;
	
	//valor total de dano
	public int damage;
	
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
		PH = Player.GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter(Collision other)
    {
		//se a colisão for do collider principal do player (e não o de grab)
		if(other.gameObject.CompareTag("Player") && other.collider != PH.GrabCollider)
			PH.TakeDamage(damage);
		
		if(deleteOnHit)
			Destroy(gameObject);
    }
}
