using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	//texto que mostra o total de HP no UI
	public Text txt;
	//script de PlayerMovement
	public PlayerMovement PM;
	//collider do grab, usado em outros scripts pra colisões nesse collider não darem dano no player
	public BoxCollider GrabCollider;
	
	//vida e vida máxima
	public int HP, maxHP;
	
    void Start()
    {
        SetText();
    }

	
	void SetText()
	{
		//string text é "HP: " seguido de int HP como string
		txt.text = "HP: " + HP;
	}
	
	//usado quando algo da dano no jogador
	public void TakeDamage(int dmg)
	{
		//da int dmg de dano no jogador até um mínimo de HP == 0
		for(var i = 0; i < dmg; i++)
		{
			if(HP > 0)
				HP--;
			else
			{
				i = dmg;
				//jogador morre
				PM.ChangeState(PlayerMovement.PlayerState.Dead);
			}
		}
		
		//atualiza o HP na UI
		SetText();
	}
	
	//usado quando algo cura o jogador
	public void RestoreHP(int heal)
	{
		//cura int heal de vida do jogador até um máximo de HP == maxHP
		for(var i = 0; i < heal; i++)
		{
			if(HP < maxHP)
				HP++;
			else
				i = heal;
		}
		
		//atualiza o HP na UI
		SetText();
	}
}