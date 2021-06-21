using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateDmg : MonoBehaviour
{
    public DamagePlayer DP;
	
	public void DeactivateScript()
	{
		DP.enabled = false;
	}
}
