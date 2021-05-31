using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    [SerializeField]
	GameObject Player;
	[SerializeField]
	PlayerHealth PH;
	
	//se o objeto é deletado quando colide
	public bool deleteOnHit;
	
	//valor total de cura
	public int healing;
	
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
		PH = Player.GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter(Collision other)
    {
		if(other.gameObject.CompareTag("Player"))
			PH.RestoreHP(healing);
		
		if(deleteOnHit)
			Destroy(gameObject);
    }
}
