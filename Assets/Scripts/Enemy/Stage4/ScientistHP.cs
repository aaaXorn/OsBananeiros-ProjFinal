using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistHP : MonoBehaviour
{
	//script de AI do boss
	public ScientistAI SAI;
	
	//vida do boss
	public int HP;
	
	void Start()
	{
		
	}
	
	public void TakeDamage()
	{
		SAI.barrels--;
		
		HP--;
		
		//fim da boss fight
		if(HP <= 0)
			SAI.currentPatt = ScientistAI.Pattern.Dead;
		//else SAI.currentPatt = ScientistAI.Pattern.Damage;
	}
}