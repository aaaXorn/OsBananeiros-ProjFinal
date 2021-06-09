using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScenes : MonoBehaviour
{
	//menu com as opções de lingua do jogo
	public GameObject LanguageMenu;
	//acesso ao SaveManager, usado para salvar o jogo e checar variáveis
	public SaveManager SM;
	public TransitionScript TS;
	//textos, mudam de acordo com a lingua escolhida pelo jogador
	public Text txtTest, txtLanguage, txtQuitGame, 
				txtStage1;
	
	private void Start()
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
			txtStage1.text = "Stage 1";
			break;
			
			case "Portugues":
			txtTest.text = "Teste";
			txtLanguage.text = "Língua";
			txtQuitGame.text = "Sair do Jogo";
			txtStage1.text = "Nível 1";
			break;
		}
	}
	
	//fecha o jogo
	public void ExitGame()
	{
		SM.Save();
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
		SM.Save();
		TS.Transition(false, "Stage1");
	}
	
	//carrega o segundo stage
	public void LoadStage2()
	{
		SM.Save();
		TS.Transition(false, "Stage2");
	}
	
	//carrega o terceiro stage
	public void LoadStage3()
	{
		SM.Save();
		TS.Transition(false, "Stage3");
	}
	
	//carrega o quarto stage
	public void LoadStage4()
	{
		SM.Save();
		TS.Transition(false, "Stage4");
	}
	
	//carrega a scene de teste
	public void LoadTest()
	{
		SM.Save();
		TS.Transition(false, "SampleScene");
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