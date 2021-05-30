using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	//texto que mostra o total de HP no UI
	public Text txt;
	
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
	public void TakeDamage(int damage)
	{
		
		//atualiza o HP na UI
		SetText();
	}
	
	//usado quando algo cura o jogador
	public void Heal(int healing)
	{
		
		//atualiza o HP na UI
		SetText();
	}
}
