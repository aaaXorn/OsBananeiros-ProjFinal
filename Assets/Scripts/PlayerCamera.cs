using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public GameObject FollowTarget;
	GameObject CameraDummy;
	//variávies para ajeitar o funcionamento da camera
	public float adjustY, transformAdjustY, adjustDistance, adjustRotation;
	
    // Start is called before the first frame update
    void Start()
    {
		//cria um objeto novo pra usar na rotação da camera
        CameraDummy = new GameObject("CamDummy");
		FollowTarget.GetComponent<PlayerMovement>().SetCameraDummy(CameraDummy);
    }

    // Update is called once per frame
    void Update()
    {
		//move o dummy
		CameraDummy.transform.position = FollowTarget.transform.position;
		//move a camera
		transform.position = CameraDummy.transform.position - CameraDummy.transform.forward * adjustDistance + Vector3.up * transformAdjustY;
		//rotaciona a camera
        transform.LookAt(FollowTarget.transform.position + Vector3.up * adjustY);
		//rotaciona o dummy, que muda a rotação e posição da camera
		CameraDummy.transform.Rotate(0, Input.GetAxis("Mouse X") * adjustRotation, 0);
    }
}