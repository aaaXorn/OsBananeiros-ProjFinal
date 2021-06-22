using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3CheckpointSpawn : MonoBehaviour
{
    public SaveManager SM;
	public Transform transfRatoelho;
	
	//objetos de chase
	public S3Chase SC1, SC2, SC3;
	
	//spawn points, selecionados com base no número de checkpoints pego
	public Vector3 Spawn1, Spawn2, Spawn3;
	
    void Start()
    {
        switch(SM.S3Checkpoints)
		{
			case 1:
				transfRatoelho.position = Spawn2;
				SC2.start = true;
				break;
				
			case 2:
				transfRatoelho.position = Spawn3;
				SC3.start = true;
				break;
				
			default:
				transfRatoelho.position = Spawn1;
				SC1.start = true;
				break;
		}
    }
}
