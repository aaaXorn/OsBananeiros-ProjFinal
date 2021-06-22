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
	public Text txtLanguage, txtQuitGame, txtNewGame, txtLoadGame;
	
	private void Start()
	{
		//deixa o cursor visível
		Cursor.visible = true;
		
		SetText();
	}
	
	//deixa os textos na lingua escolhida pelo player
	public void SetText()
	{
		switch (SM.GameLanguage)
		{
			case "English":
			txtLanguage.text = "Language";
			txtQuitGame.text = "Quit Game";
			txtNewGame.text = "New Game";
			txtLoadGame.text = "Load Game";
			break;
			
			case "Portugues":
			txtLanguage.text = "Língua";
			txtQuitGame.text = "Sair do Jogo";
			txtNewGame.text = "Novo Jogo";
			txtLoadGame.text = "Continuar";
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
		SM.S1Checkpoint = false;
		SM.S2Checkpoint = false;
		SM.CurrentStage = "Stage1";
		SM.Score = 0;
		SM.Save();
		TS.Transition(false, "Stage1");
	}
	
	public void LoadGame()
	{
		SM.Save();
		TS.Transition(false, SM.CurrentStage);
	}
	
	public void LoadLevel()
	{
		
	}
	
	//carrega o primeiro stage
    public void LoadStage1()
	{
		SM.S1Checkpoint = false;
		SM.Save();
		TS.Transition(false, "Stage1");
	}
	
	//carrega o segundo stage
	public void LoadStage2()
	{
		SM.S2Checkpoint = false;
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