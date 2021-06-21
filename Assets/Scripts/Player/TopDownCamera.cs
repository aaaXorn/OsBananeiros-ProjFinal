using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
	public GameObject FollowTarget;
	GameObject CameraDummy;
	
	//variáveis que mudam o comportamento da câmera
	public float adjustDistance, adjustX;
	
	//se é pra câmera rotacionar
	public bool rotate;
	//timer da rotação
	public float rotTimer;
	//velocidade da rotação
	public float rotSpeed;
	
    void Start()
    {
		//cria um objeto para a câmera seguir
        CameraDummy = new GameObject("CamDummy");
		FollowTarget.GetComponent<PlayerMovement>().SetCameraDummy(CameraDummy);
    }

    void Update()
    {
		//gruda o objeto que a câmera segue no jogador
		CameraDummy.transform.position = FollowTarget.transform.position;
		
		//posiciona a câmera baseado no CameraDummy
		transform.position = CameraDummy.transform.position - CameraDummy.transform.forward * adjustX + Vector3.up * adjustDistance;
		
		//rotaciona a câmera para ela olhar pro player
		transform.LookAt(FollowTarget.transform.position);
		
		if(rotate)
		{
			if(rotTimer > 0)
			{
				//rotaciona o CameraDummy, causando uma rotação na câmera
				CameraDummy.transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
				
				rotTimer -= Time.deltaTime;
			}
			else
				rotate = false;
		}
    }
	
	void RotateCamera(float timer, float spd)
	{
		rotate = true;
		rotTimer = timer;
		rotSpeed = spd;//>0 pra esquerda, <0 pra direita
	}
}
