using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public GameObject FollowTarget;
	GameObject CameraDummy;
	
	//variáveis que mudam o comportamento da câmera
	public float adjustY, transformAdjustY, adjustDistance, adjustRotation;
	public bool mayRotate;
	
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
		transform.position = CameraDummy.transform.position - CameraDummy.transform.forward * adjustDistance + Vector3.up * transformAdjustY;
		
		if(mayRotate)
		{
			//rotaciona a câmera baseado no CameraDummy
			transform.LookAt(FollowTarget.transform.position + Vector3.up * adjustY);
			
			//rotaciona o CameraDummy, causando uma rotação na câmera
			CameraDummy.transform.Rotate(0, Input.GetAxis("Mouse X") * adjustRotation * Time.deltaTime, 0);
		}
    }
}
