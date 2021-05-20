using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	public GameObject FollowTarget;
	GameObject CameraDummy;
	
	public float adjustY, transformAdjustY, adjustDistance, adjustRotation;
	
    // Start is called before the first frame update
    void Start()
    {
        CameraDummy = new GameObject("CamDummy");
		//FollowTarget.GetComponent<script>().SetDummyCam(CameraDummy);
    }

    // Update is called once per frame
    void Update()
    {
		CameraDummy.transform.position = FollowTarget.transform.position;
		
		transform.position = CameraDummy.transform.position - CameraDummy.transform.forward * adjustDistance + Vector3.up * transformAdjustY;
		
        transform.LookAt(FollowTarget.transform.position + Vector3.up * adjustY);
		
		CameraDummy.transform.Rotate(0, Input.GetAxis("Mouse X") * adjustRotation, 0);
    }
}
