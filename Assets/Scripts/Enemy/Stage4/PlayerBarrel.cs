using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrel : MonoBehaviour
{
	public ScientistAI SAI;
	
	public GameObject ExplodeSFX;
	
	public Rigidbody rigid;
	
    public float speed;
	public Vector3 Movement;
	
	public bool destroy;
	
    void Update()
    {
        Movement = new Vector3(0, rigid.velocity.y, speed);
		
		rigid.velocity = transform.TransformDirection(Movement);
    }
	
	void OnCollisionEnter(Collision other)
	{
		//quando toca na parede, spawna o outro barril e é destruído
		if(other.gameObject.CompareTag("Wall") && speed != 0)
		{
			if(!destroy)
			{
				SAI.barrels--;
				
				ExplodeSFX.SetActive(true);
				
				destroy = true;
			}
			
			Destroy(gameObject, 0.5f);
		}
		
		//se colide com o boss
		if(other.gameObject.CompareTag("Boss"))
		{
			if(!destroy)
			{
				SAI.SHP.TakeDamage();
				
				ExplodeSFX.SetActive(true);
				
				destroy = true;
			}
			
			Destroy(gameObject, 0.5f);
		}
	}
}