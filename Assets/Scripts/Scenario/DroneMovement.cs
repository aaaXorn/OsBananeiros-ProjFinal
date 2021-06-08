using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
	public Transform transfTarget;
	
	public float sMjrAxis;//raio direção X, posição inicial
	public float sMnrAxis;//raio direção Z
	public float angle;//ângulo
	public float speedMod;//velocidade do movimento
	public float eccentricity;//diferença entre raio X e Z
	float speed;
	float xPos, zPos;//posição do objeto

	void Start()
	{
		speed = (speedMod * Mathf.PI) / 10;//Mathf.PI = π
	}

    void Update()
    {
		//setta o raio Z
		sMnrAxis = Mathf.Sqrt(Mathf.Pow(sMjrAxis, 2) * (1 - Mathf.Pow(eccentricity, 2)));
		
		//setta o ângulo da rotação
		angle += speed * Time.deltaTime;
		//setta as posições do objeto
		xPos = Mathf.Cos(angle) * sMjrAxis;
		zPos = Mathf.Sin(angle) * sMnrAxis;
		//localPosition faz o objeto rodar ao redor do gameObject parent (transfTarget)
		transform.localPosition = new Vector3(xPos, 0, zPos);
		
		//rotaciona para o objeto olhar para transfTarget
		transform.LookAt(transfTarget);
    }
}
