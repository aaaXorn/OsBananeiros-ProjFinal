using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidFlaskV2 : MonoBehaviour
{
	//posição em que o stage hazard será spawnado
	public Transform Target;
	//posição que o frasco subirá antes de ser arremessado
	public Vector3 RisePos;
	
	//stage hazard de ácido
	public GameObject AcidSpawn;
	
	//variáveis de movimento
	public float height, diveSpd, riseSpd;
	//timer, quando 0 faz o frasco ir até Target
	public float riseTimer;
	
    void Start()
    {
		//setta a posição do movimento para cima
        RisePos = new Vector3 (transform.position.x, transform.position.y + height, transform.position.z);
    }

    void Update()
    {
		if(riseTimer >= 0)
		{
			//move o frasco para cima
			transform.position = Vector3.MoveTowards(transform.position, RisePos, riseSpd * Time.deltaTime);
			
			riseTimer -= Time.deltaTime;
		}
		else
		{
			//move o frasco até o alvo
			transform.position = Vector3.MoveTowards(transform.position, Target.position, diveSpd * Time.deltaTime);
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
