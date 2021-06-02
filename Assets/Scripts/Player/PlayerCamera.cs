using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	[SerializeField]
	Pause pause;
	
	public GameObject FollowTarget;
	GameObject CameraDummy;
	
	public float adjustY, transformAdjustY, adjustDistance, adjustRotation;
	
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
		
		//rotaciona a câmera baseado no CameraDummy
        transform.LookAt(FollowTarget.transform.position + Vector3.up * adjustY);
		
		//para não rotacionar a câmera quando o jogo está pausado
		if(!pause.gamePaused)
		{
			//rotaciona o CameraDummy, causando uma rotação na câmera
			CameraDummy.transform.Rotate(0, Input.GetAxis("Mouse X") * adjustRotation, 0);
		}
    }
}
