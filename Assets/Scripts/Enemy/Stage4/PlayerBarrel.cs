using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrel : MonoBehaviour
{
	public ScientistAI SAI;
	
	public Rigidbody rigid;
	
    public float speed;
	public Vector3 Movement;
	
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
			SAI.barrels--;
			
			Destroy(gameObject);
		}
		
		//se colide com o boss
		if(other.gameObject.CompareTag("Boss"))
		{
			SAI.SHP.TakeDamage();
			
			Destroy(gameObject);
		}
	}
}
