using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAtk : MonoBehaviour
{
	public ScientistAI SAI;
	
	public Rigidbody rigid;
	
	//barril que o jogador usa
	public GameObject Barrel2;
	
	//velocidade
	public float speed;
	//vetor de movimento
	public Vector3 Movement;
	
	public bool stop;
	
	public GameObject Spin;

	void Start()
	{
		Movement = new Vector3 (0, 0, speed);
	}

    void FixedUpdate()
    {
        rigid.velocity = transform.TransformDirection(Movement);
		
		Spin.transform.Rotate(0, 5, 0);
    }
	
	void OnCollisionEnter(Collision other)
	{
		//quando toca na parede, spawna o outro barril e é destruído
		if(other.gameObject.CompareTag("Wall"))
		{
			if(!stop)
			{
				GameObject otherBarrel = Instantiate(Barrel2, transform.position, transform.rotation);
				
				otherBarrel.transform.Rotate(0, 180, 0);
				otherBarrel.GetComponent<PlayerBarrel>().Spin.transform.Rotate(0, transform.rotation.y - 180, 0);
				
				otherBarrel.GetComponent<PlayerBarrel>().SAI = SAI;
				
				stop = true;
			}
			
			Destroy(gameObject);
		}
	}
}
