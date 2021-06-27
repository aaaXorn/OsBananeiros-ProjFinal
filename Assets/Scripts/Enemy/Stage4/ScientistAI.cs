using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistAI : MonoBehaviour
{
	//script de HP do boss
	public ScientistHP SHP;
	
	public UnityEngine.AI.NavMeshAgent agent;
	
	//transform do player,
	public Transform trnfPlayer;
	//posição de Idle do boss
	public Vector3 IdlePos;
	
	//variáveis de cooldown
	public float timerCD, maxCD;
	
	//variáveis de morte do boss
	public float deathTimer;
	
	//variáveis de ataque do boss
	public int acidUses, barrels;
	public bool atkStart;
	
	public GameObject AcidPrefab, BarrelPrefab;
	
	//variávies de raycast pro Slap()
	//onde o raycast começa, seu tamanho
	[SerializeField] float raycastStartPoint, raycastSize;
	//informação do que o raycast acertou
	RaycastHit hitInfo;
	
	//patterns do boss
	public enum Pattern
	{
		CD,
		//Damage,
		Dead,
		
		Slap,
		Acid,
		Barrel,
	}
	//pattern atual do boss
	public Pattern currentPatt;
	
	void Start()
	{
		
	}
	
	void FixedUpdate()
	{
		//usa a função void com nome igual ao do currentPatt
		Invoke(currentPatt.ToString(), 0);
	}

	void CD()
	{
		//cooldown
		if(timerCD <= maxCD)
		{
			timerCD += Time.deltaTime;
			
			agent.SetDestination(IdlePos);
		}
		//faz o boss fazer um dos ataques
		else
		{
			timerCD = 0;
			atkStart = false;
			
			if(barrels > 0)
			{
				if(acidUses <= 0)
					currentPatt = Pattern.Slap;
				else
					currentPatt = Pattern.Acid;
			}
			else
				currentPatt = Pattern.Barrel;
		}
	}
	
	void Dead()
	{
		
	}
	
	void Slap()
	{
		//se move até a posição do tapa
		if(!atkStart)
		{
			agent.SetDestination(trnfPlayer.position);
			
			//para visualizar o raycast
			Debug.DrawLine(transform.position + (transform.forward * raycastStartPoint), transform.position + (transform.forward * raycastSize), Color.white);
			//gera o raycast
			Physics.Raycast(transform.position + (transform.forward * raycastStartPoint), transform.forward, out hitInfo, raycastSize);
		
			//para impedir erros
			if(hitInfo.collider != null)
			{
				//se o raycast acertar a bancada
				if(hitInfo.collider.tag == "BossArena")
				{
					atkStart = true;
				}
			}
		}
		//da o tapa
		else
		{
			
		}
	}
	
	void Acid()
	{
		
	}
	
	void Barrel()
	{
		
	}
}