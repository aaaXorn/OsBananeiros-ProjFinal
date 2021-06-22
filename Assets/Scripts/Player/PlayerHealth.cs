using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	//texto que mostra o total de HP no UI
	//public Text txt;
	//script de PlayerMovement
	public PlayerMovement PM;
	//collider do grab, usado em outros scripts pra colisões nesse collider não darem dano no player
	public BoxCollider GrabCollider;
	
	//audio
	public AudioSource audioS;
	public AudioClip damageSFX;
	
	//vida e vida máxima
	public int HP, maxHP;
	
	//timer de invulnerabilidade
	public float invulTimer, maxInvul = 2;
	
	//sprites do UI
	public Transform transfHP;
	public Image prefabHP;
	//array de imagens
	Stack<Image> healthSpr;
	//variáveis de posicionamento dos sprites
	public float sprPosMult, sprPosAdd, sprPosAddInst;
	
    void Start()
    {
        //SetText();
		//cria o array de imagens
		healthSpr = new Stack<Image>();
		for(int i = 0; i < HP; i++)
		{
			AddSpr();
		}
    }

	void Update()
	{
		//impede o jogador de tomar muitos hits seguidos
		if(invulTimer < maxInvul)
			invulTimer += Time.deltaTime;
	}
	
	/*void SetText()
	{
		//string text é "HP: " seguido de int HP como string
		txt.text = "HP: " + HP;
	}*/
	
	//usado quando algo da dano no jogador
	public void TakeDamage(int dmg, bool ignInvul, float knkb)//ignInvul é se ignora invulnerabilidade, knkb é knockback
	{
		//se o jogador não estiver invulnerável
		if(invulTimer >= maxInvul || ignInvul)
		{
			//da int dmg de dano no jogador até um mínimo de HP == 0
			for(var i = 0; i < dmg; i++)
			{
				//uma vez por ataque tomado
				if(i == 0)
				{
					//faz o SFX de dano
					audioS.PlayOneShot(damageSFX);
					//da knockback e stunna o player
					PM.Knockback(knkb);
				}
				
				if(HP > 1)
				{
					HP--;
					RemoveSpr();
				}
				else
				{
					HP = 0;
					RemoveSpr();
					i = dmg;
					//jogador morre
					PM.ChangeState(PlayerMovement.PlayerState.Dead);
				}
			}
			
			//atualiza o HP na UI
			//SetText();
			
			//deixa o jogador temporáriamente invulnerável
			invulTimer = 0;
		}
	}
	
	//usado quando algo cura o jogador
	public void RestoreHP(int heal)
	{
		//cura int heal de vida do jogador até um máximo de HP == maxHP
		for(var i = 0; i < heal; i++)
		{
			if(HP < maxHP)
			{
				HP++;
				AddSpr();
			}
			else
				i = heal;
		}
		
		//atualiza o HP na UI
		//SetText();
	}
	
	public void RemoveSpr()
	{
		//destroi o último Image do Array
		Image img = healthSpr.Pop();
		if(img) Destroy(img);
	}
	
	public void AddSpr()
	{
		//cria um novo Image no Array
		float posX = prefabHP.rectTransform.sizeDelta.x * healthSpr.Count * sprPosMult + sprPosAdd;
		healthSpr.Push(
					   Instantiate(prefabHP, transfHP.position + new Vector3((posX - sprPosAddInst), 0, 0),
								   Quaternion.identity, transfHP)
					  );
	}
}