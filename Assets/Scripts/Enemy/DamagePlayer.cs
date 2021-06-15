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
	//valor do knockback
	public float knockback;
	
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
		PH = Player.GetComponent<PlayerHealth>();
		
		if(knockback == 0)
			knockback = 750;
    }

    void OnCollisionEnter(Collision other)
    {
		//pro script não usar essa função desativado
		if(gameObject.GetComponent<DamagePlayer>().enabled)
		{
			//se a colisão for do collider principal do player (e não o de grab)
			if(other.gameObject.CompareTag("Player") && other.collider != PH.GrabCollider)
				PH.TakeDamage(damage, knockback);
			
			if(deleteOnHit)
				Destroy(gameObject);
		}
    }
}
