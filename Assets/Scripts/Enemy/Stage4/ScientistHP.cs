using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistHP : MonoBehaviour
{
	//script de AI do boss
	public ScientistAI SAI;
	
	//vida do boss
	public int HP;
	
	[SerializeField]
	AudioSource HitSFX, UnlockSFX;
	
	public void TakeDamage()
	{
		SAI.barrels--;
		
		HP--;
		
		HitSFX.Play();
		
		//fim da boss fight
		if(HP <= 0)
		{
			if(HP == 0)
				UnlockSFX.Play();
			SAI.currentPatt = ScientistAI.Pattern.Dead;
		}
		else
			SAI.acidUses++;
	}
}