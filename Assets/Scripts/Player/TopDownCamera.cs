using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
	public GameObject FollowTarget;
	GameObject CameraDummy;
	
	//variáveis que mudam o comportamento da câmera
	public float adjustDistance, adjustX;
	
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
    }
}
