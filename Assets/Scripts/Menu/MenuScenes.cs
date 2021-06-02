using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScenes : MonoBehaviour
{
	public void NewGame()
	{
		
	}
	
	public void LoadGame()
	{
		
	}
	
	public void LoadLevel()
	{
		
	}
	
    public void LoadStage1()
	{
		SceneManager.LoadScene("Stage1");
	}
	
	public void LoadStage2()
	{
		SceneManager.LoadScene("Stage2");
	}
	
	public void LoadStage3()
	{
		SceneManager.LoadScene("Stage3");
	}
	
	public void LoadStage4()
	{
		SceneManager.LoadScene("Stage4");
	}
}
