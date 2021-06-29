using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScientistAI : MonoBehaviour
{
	//script de HP do boss
	public ScientistHP SHP;
	public Animator anim;
	
	public NavMeshAgent agent;
	
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
	public float atkTimer;
	//valor que atkTimer tem que ser >= para completar o ataque
	public float slapTimer, acidTimer, barrelTimer;
	
	//prefab dos projéteis
	public GameObject AcidPrefab, BarrelPrefab;
	//spawn em relação ao cientista
	public Vector3 SpawnPoint;
	
	//variávies de raycast pro Slap()
	//onde o raycast começa, seu tamanho
	[SerializeField] float raycastStartPoint, raycastSize;
	//informação do que o raycast acertou
	RaycastHit hitInfo;
	
	public bool dead;
	//alçapão que é aberto quando o boss morre
	public GameObject Alcapao;
	
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
		
		//para a animação de movimento
		anim.SetFloat("Velocity", agent.velocity.magnitude);
	}

	void CD()
	{
		//se o boss estava atacando, reseta variáveis e volta a animação pra Idle
		if(atkStart)
		{
			anim.SetTrigger("Idle");
			
			timerCD = 0;
			atkTimer = 0;
			atkStart = false;
		}
		
		//cooldown
		if(timerCD <= maxCD)
		{
			timerCD += Time.deltaTime;
			
			agent.SetDestination(IdlePos);
		}
		//faz o boss fazer um dos ataques
		else
		{
			//if(barrels > 0)
			if(acidUses <= 0)
			{
				//if(acidUses <= 0)
				if(barrels > 0)
					currentPatt = Pattern.Slap;
				else
				{
					//acidUses--;
					//currentPatt = Pattern.Acid;
					barrels++;
					currentPatt = Pattern.Barrel;
				}
			}
			else
			{
				//barrels++;
				//currentPatt = Pattern.Barrel;
				acidUses--;
				currentPatt = Pattern.Acid;
			}
		}
	}
	
	void Dead()
	{
		if(!dead)
		{
			agent.SetDestination(transform.position);
			
			Alcapao.transform.Rotate(0, 0, -32);
			
			dead = true;
		}
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
				if(hitInfo.collider.tag == "Wall")
				{
					anim.SetTrigger("Slap");
					
					atkStart = true;
				}
			}
		}
		//da o tapa
		else
		{
			atkTimer += Time.deltaTime;
			
			if(atkTimer >= slapTimer)
				currentPatt = Pattern.CD;
		}
	}
	
	void Acid()
	{
		if(!atkStart)
		{
			anim.SetTrigger("Throw");
			
			atkStart = true;
		}
		
		atkTimer += Time.deltaTime;
		
		//spawna o ácido e encerra o ataque
		if(atkTimer >= acidTimer)
		{
			GameObject Flask = Instantiate(AcidPrefab, transform.position, transform.rotation);
			//faz o frasco não spawnar dentro do boss
			Vector3 spawn = transform.TransformDirection(SpawnPoint);
			Flask.transform.position = Flask.transform.position + spawn;
			
			//define a posição de alvo do frasco
			Flask.GetComponent<AcidFlaskV2>().Target = new Vector3(trnfPlayer.position.x, 2, trnfPlayer.position.z);
			
			currentPatt = Pattern.CD;
		}
	}
	
	void Barrel()
	{
		if(!atkStart)
		{
			anim.SetTrigger("Throw");
			
			atkStart = true;
		}
		
		atkTimer += Time.deltaTime;
		
		//arremessa o barril e encerra o ataque
		if(atkTimer >= barrelTimer)
		{
			GameObject BarrelT = Instantiate(BarrelPrefab, transform.position, transform.rotation);
			//faz o barril não spawnar dentro do boss
			Vector3 spawn = transform.TransformDirection(SpawnPoint) - (Vector3.up * 3.5f);
			BarrelT.transform.position = BarrelT.transform.position + spawn;
			
			//define a variável ScientistAI (script) de BarrelAtk
			BarrelT.GetComponent<BarrelAtk>().SAI = gameObject.GetComponent<ScientistAI>();
			
			currentPatt = Pattern.CD;
		}
		//rotaciona o boss pra ele jogar o barril pro lado certo
		else
			transform.LookAt(trnfPlayer.position);
	}
}