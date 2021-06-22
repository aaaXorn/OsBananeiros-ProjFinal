using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public Text txtScore;
	
    public int score;
	
    void Start()
    {
        SetScore(0);
    }

    public void SetScore(int scr)
	{
		score += scr;
		
		txtScore.text = "SCORE: " + score;
	}
}
