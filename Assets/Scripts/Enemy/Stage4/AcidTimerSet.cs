using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidTimerSet : MonoBehaviour
{
	public AcidFlask AF;
	
	public float currentDist;
	public float timerCalc;
	
    void Update()
    {
		//posição atual
		currentDist = ((transform.position - AF.Target.position).magnitude);
		
		if(currentDist > AF.quarterDist)
		{
			transform.position = Vector3.MoveTowards(transform.position, AF.TargetPos, AF.speed * Time.deltaTime);
			timerCalc += Time.deltaTime;
		}
		//se passar do ponto quarterDist
		else
		{
			//faz o movimento do frasco começar
			AF.quarterTimer = timerCalc;
			AF.start = true;
			Destroy(gameObject);
		}
    }
}
