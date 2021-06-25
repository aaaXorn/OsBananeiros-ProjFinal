using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidFlask : MonoBehaviour
{
	public Transform Target;
	public Vector3 TargetPos;
	
	public bool start;
	
	//usadas para decidir a parte do movimento da pseudo-parábola
	public float quarterDist;
	public float timer, quarterTimer;
	public int moveState;
	
	//velocidade X
    public float speed;
	
	//altura da pseudo-parábola
	public float height, maxHeight, minHeight;
	
	//stage hazard de ácido
	public GameObject AcidSpawn;
	
	void Start()
	{
		minHeight = transform.position.y;
		maxHeight = height + transform.position.y;
		
		quarterDist = ((transform.position - Target.position).magnitude) * 3/4;
		
		//posição X e Z que o objeto irá se mover para
		TargetPos = new Vector3(Target.position.x, transform.position.y, Target.position.z);
	}
	
    void FixedUpdate()
	{
		if(start)
		{
			TargetPos = new Vector3(Target.position.x, transform.position.y, Target.position.z);
			
			//move o frasco
			transform.position = Vector3.MoveTowards(transform.position, TargetPos, speed * Time.deltaTime);
			
			//movimento vertical da pseudo-parábola
			timer += Time.deltaTime;
			switch(moveState)
			{
				//move rapidamente para +Y
				case 0:
					transform.position = new Vector3(transform.position.x, Mathf.Lerp(minHeight, maxHeight - height/3, timer / quarterTimer), transform.position.z);
					if(timer >= quarterTimer)
					{
						timer = 0;
						moveState++;
					}
					break;
				
				//move lentamente para +Y
				case 1:
					transform.position = new Vector3(transform.position.x, Mathf.Lerp(maxHeight - height/3, maxHeight, timer / quarterTimer), transform.position.z);
					if(timer >= quarterTimer)
					{
						timer = 0;
						moveState++;
					}
					break;
					
				//move lentamente para -Y
				case 2:
					transform.position = new Vector3(transform.position.x, Mathf.Lerp(maxHeight, maxHeight - height/3, timer / quarterTimer), transform.position.z);
					if(timer >= quarterTimer)
					{
						timer = 0;
						moveState++;
					}
					break;
				
				//move rapidamente para -Y
				case 3:
					transform.position = new Vector3(transform.position.x, Mathf.Lerp(maxHeight - height/3, minHeight, timer / quarterTimer), transform.position.z);
					if(timer >= quarterTimer)
					{
						timer = 0;
						moveState++;
					}
					break;
				
				default:
					break;
			}
		}
    }
	
	void OnCollisionEnter(Collision other)
	{
		//quando toca na bancada, spawna o stage hazard e é destruído
		if(other.gameObject.CompareTag("BossArena"))
		{
			Instantiate(AcidSpawn, Target.position + Vector3.down, Target.rotation);
			
			Destroy(gameObject);
		}
	}
}
