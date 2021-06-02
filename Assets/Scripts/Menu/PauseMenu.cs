using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	//acesso ao SaveManager
	public SaveManager SM;
	//textos, mudam de acordo com a lingua escolhida pelo jogador
	public Text txtQuitMenu, txtQuitGame;
	
	private void Awake()
	{
		SetText();
	}
	
	//deixa os textos na lingua escolhida pelo player
	public void SetText()
	{
		switch (SM.GameLanguage)
		{
			case "English":
			txtQuitMenu.text = "Quit to Menu";
			txtQuitGame.text = "Quit Game";
			break;
			
			case "Portugues":
			txtQuitMenu.text = "Voltar para o Menu";
			txtQuitGame.text = "Sair do Jogo";
			break;
		}
	}
	
	//volta para o main menu
    public void MainMenu()
	{
		SceneManager.LoadScene("Menu");
	}
	
	//fecha o jogo
	public void ExitGame()
	{
		Application.Quit();
	}
}
