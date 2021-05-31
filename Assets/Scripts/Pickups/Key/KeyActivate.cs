using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyActivate : MonoBehaviour
{
	//tag que o outro objeto precisa ter e função que será chamada
	public string keyType, message;
	
    void OnCollisionEnter(Collision other)
    {
		if(other.gameObject.CompareTag(keyType))
		{
			//chama uma função com o nome igual ao conteúdo da string message
			other.gameObject.SendMessage(message);
		}
	}
}
