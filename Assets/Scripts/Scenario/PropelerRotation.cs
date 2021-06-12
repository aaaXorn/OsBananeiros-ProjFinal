using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelerRotation : MonoBehaviour
{
    [SerializeField]
	float rotationSpd;

    void FixedUpdate()
    {
		//faz o objeto rotacionar
        transform.Rotate(0, 0, rotationSpd);
    }
}
