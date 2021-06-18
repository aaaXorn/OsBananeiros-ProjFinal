using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	[SerializeField]
	GameObject PauseMenu, Clipboard;
	
	//se o jogo está ou não pausado, usado em partes de outros códigos pro pause funcionar
	public bool gamePaused = false;
	
	//se o pause foi causado por um item de prancheta ou não
	public bool clipboard;
	
	//velocidade do tempo quando o jogo está despausado
    float unpausedTimeScale = 1;

	void Start()
	{
		//deixa o cursor invisível
		Cursor.visible = false;
	}

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
		{
			clipboard = false;
			
			if(!gamePaused)
				PauseGame();
			else
				UnpauseGame();
		}
    }
	
	void PauseGame()
	{
		gamePaused = true;
		
		//deixa o cursor visível
		Cursor.visible = true;
		
		PauseMenu.SetActive(true);
		
		//faz o tempo na Unity parar, pausando o jogo
		Time.timeScale = 0;
	}
	
	void UnpauseGame()
	{
		gamePaused = false;
		
		//deixa o cursor invisível
		Cursor.visible = false;
		
		if(PauseMenu.activeSelf)
			PauseMenu.SetActive(false);
		if(Clipboard.activeSelf)
			Clipboard.SetActive(false);
		
		//volta o tempo ao normal, despausando o jogo
		Time.timeScale = unpausedTimeScale;
	}
	
	public void ClipboardPause()
	{
		gamePaused = true;
		
		//deixa o cursor visível
		Cursor.visible = true;
		
		Clipboard.SetActive(true);
		
		//faz o tempo na Unity parar, pausando o jogo
		Time.timeScale = 0;
	}
}
