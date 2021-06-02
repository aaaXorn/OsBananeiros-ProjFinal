using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScenes : MonoBehaviour
{
	//menu com as opções de lingua do jogo
	public GameObject LanguageMenu;
	//acesso ao SaveManager
	public SaveManager SM;
	//textos, mudam de acordo com a lingua escolhida pelo jogador
	public Text txtTest, txtLanguage, txtQuitGame;
	
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
			txtTest.text = "Test";
			txtLanguage.text = "Language";
			txtQuitGame.text = "Quit Game";
			break;
			
			case "Portugues":
			txtTest.text = "Teste";
			txtLanguage.text = "Língua";
			txtQuitGame.text = "Sair do Jogo";
			break;
		}
	}
	
	//fecha o jogo
	public void ExitGame()
	{
		Application.Quit();
	}
	
	public void NewGame()
	{
		
	}
	
	public void LoadGame()
	{
		
	}
	
	public void LoadLevel()
	{
		
	}
	
	//carrega o primeiro stage
    public void LoadStage1()
	{
		SceneManager.LoadScene("Stage1");
	}
	
	//carrega o segundo stage
	public void LoadStage2()
	{
		SceneManager.LoadScene("Stage2");
	}
	
	//carrega o terceiro stage
	public void LoadStage3()
	{
		SceneManager.LoadScene("Stage3");
	}
	
	//carrega o quarto stage
	public void LoadStage4()
	{
		SceneManager.LoadScene("Stage4");
	}
	
	//carrega a scene de teste
	public void LoadTest()
	{
		SceneManager.LoadScene("SampleScene");
	}
	
	//abre o menu que deixa o jogador escolher a lingua do jogo
	public void LanguageChoice()
	{
		LanguageMenu.SetActive(!LanguageMenu.activeSelf);
	}
	
	//muda a lingua do jogo para inglês
	public void English()
	{
		SM.GameLanguage = "English";
		SetText();
	}
	
	//muda a lingua do jogo para português
	public void Portugues()
	{
		SM.GameLanguage = "Portugues";
		SetText();
	}
}