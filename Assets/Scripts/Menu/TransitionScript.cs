using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
	//public GameObject TransitionObj;
	public RawImage TransitionObj;
	
	[SerializeField]
	bool start, varSet;//se a transição começou e se as variáveis da transição foram settadas
	[SerializeField]
	bool open;//tipo da transição, true abre a cena, false fecha
	[SerializeField]
	string sceneName;//scene a ser aberta quando a transição acaba
	
	[SerializeField]
	float transitionTimer;
	
    void Awake()
    {
		//faz a transição de abertura
        Transition(true, null);
    }

	void Update()
	{
		if(start)
		{
			//setta as variáveis usadas
			if(!varSet)
			{
				TransitionObj.enabled = true;
				
				if(open)
					transitionTimer = 1;
				else
					transitionTimer = 0;
				
				varSet = true;
			}
			
			//tela começa preta, aumenta transparência com o tempo
			if(open)
			{
				transitionTimer -= Time.unscaledDeltaTime;
				if(transitionTimer <= 0)
				{
					TransitionObj.enabled = false;
					varSet = false;
					start = false;
				}
			}
			//tela começa transparente, diminui transparência com o tempo
			else
			{
				transitionTimer += Time.unscaledDeltaTime;
				if(transitionTimer >= 1)
				{
					//muda a cena para a certa
					SceneManager.LoadScene(sceneName);
				}
			}
			
			//muda a transparência com base em transitionTimer
			TransitionObj.color = new Color(0, 0, 0, transitionTimer);
		}
	}

	public void Transition(bool type, string scene)
	{
		start = true;
		sceneName = scene;
		open = type;
	}
}
