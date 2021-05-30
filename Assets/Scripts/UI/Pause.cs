using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	//se o jogo está ou não pausado, usado em partes de outros códigos pro pause funcionar
	public bool gamePaused = false;
	
	//velocidade do tempo quando o jogo está despausado
    float unpausedTimeScale = 1;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
		{
			if(!gamePaused)
				PauseGame();
			else
				UnpauseGame();
		}
    }
	
	void PauseGame()
	{
		gamePaused = true;
		
		//faz o tempo na Unity parar, pausando o jogo
		Time.timeScale = 0;
	}
	
	void UnpauseGame()
	{
		gamePaused = false;
		
		//volta o tempo ao normal, despausando o jogo
		Time.timeScale = unpausedTimeScale;
	}
}
