using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
	//!ALERTA DE ESPAGUETE!
	//o código a seguir pode causar sintômas como dor de cabeça e questionamentos do significado da vida
	
	//objeto que a câmera deve observar
	public GameObject FollowTarget;
	//objeto que a câmera segue
	GameObject CameraDummy;
	
	//variáveis que mudam o comportamento da câmera
	public float adjustY, transformAdjustY, adjustDistance, adjustRotation;
	//se a câmera pode rotacionar
	public bool mayRotate;
	
	//alvo do movimento e rotação da câmera
	[SerializeField] Transform target = null;
	//outras variáveis que mudam o comportamento da câmera
	[SerializeField] float distance;
	[SerializeField] float height;
	[SerializeField] float damping = 5.0f;
	[SerializeField] float rotationDamping = 10.0f;
	//tipo de rotação da câmera, false parece funcionar melhor
	[SerializeField] bool smoothRotation;
 
	//(não funcional) muda a posição que a câmera observa
	[SerializeField] Vector3 targetLookAtOffset;
	
	//variáveis de raycast
	[SerializeField] float bumperDistanceCheck;//tamanho do raycast
	[SerializeField] float bumperCameraHeight;//ajusta a distância Y da câmera quando o raycast colide com algo
	[SerializeField] Vector3 bumperRayOffset;//deixa a posição inicial do raycast ser diferente da do alvo
	
	void Awake()
	{
		//cria um objeto para a câmera seguir
        CameraDummy = new GameObject("CamDummy");
		FollowTarget.GetComponent<PlayerMovement>().SetCameraDummy(CameraDummy);
		//seta o alvo da câmera como o transform do CameraDummy
		target = CameraDummy.GetComponent<Transform>();
	}
	
	void Update()
	{
		//gruda o objeto que a câmera segue no jogador
		CameraDummy.transform.position = FollowTarget.transform.position;
		
		if(mayRotate)
		{
			//rotaciona a câmera baseado no CameraDummy
			transform.LookAt(FollowTarget.transform.position + Vector3.up * adjustY);
			
			//posiciona a câmera baseado no CameraDummy
			//transform.position = CameraDummy.transform.position - CameraDummy.transform.forward * adjustDistance + Vector3.up * transformAdjustY;
			
			//rotaciona o CameraDummy, causando uma rotação na câmera
			CameraDummy.transform.Rotate(0, Input.GetAxis("Mouse X") * adjustRotation * Time.deltaTime, 0);
		}
	}
	
	void FixedUpdate() 
	{
		Vector3 wantedPosition = target.TransformPoint(0, height, -distance);
		
		//variável para checar se o raycast acertou algo
		RaycastHit hit;
		//direção -Z relativo ao jogador
		Vector3 back = target.transform.TransformDirection(-1 * Vector3.forward); 
		//cria o raycast e checa se o que foi acertando não é o alvo
		if (Physics.Raycast(target.TransformPoint(bumperRayOffset), back, out hit, bumperDistanceCheck) && hit.transform != target)
		{
			//se tiver acertado algo, muda a posição da câmera para o ponto de acerto com um modificador em Y
			wantedPosition.x = hit.point.x;
			wantedPosition.z = hit.point.z;
			wantedPosition.y = Mathf.Lerp(hit.point.y + bumperCameraHeight, wantedPosition.y, Time.deltaTime * damping);
		}
		
		//posição da câmera
		transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);
		
		//rotação da câmera, por algum motivo só não buga se usado junto com a rotação do Update
		Vector3 lookPosition = target.TransformPoint(targetLookAtOffset);
		if (smoothRotation)
		{
			Quaternion wantedRotation = Quaternion.LookRotation(lookPosition - transform.position, target.up * adjustY);
			transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		//rotação sem smooth, parece funcionar melhor no caso desse script
		else 
			transform.rotation = Quaternion.LookRotation(lookPosition - target.position, target.up);
	}
}