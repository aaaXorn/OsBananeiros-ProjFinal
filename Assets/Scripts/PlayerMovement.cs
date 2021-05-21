using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody rigid;
	GameObject CameraDummy;
	
	Vector3 Movement;//direção do movimento
	public float moveForce;//força/velocidade do movimento
	public float speedLimiterMult, speedLimiterPlus;//limitam a velocidade máxima
	
	//se o jogador está agarrando algo ou não
	bool grab;
	
	//estados do jogador
	public enum PlayerState
	{
		Idle,
		Walk,
	}
	//estado atual do jogador
	public PlayerState State;
	
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
	
	public void SetCameraDummy(GameObject dummy)
	{
		CameraDummy = dummy;
	}

    // Update is called once per frame
    void Update()
    {
		//direção do movimento
        Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		//faz a direção do movimento ser baseada na rotação da camera
		if(CameraDummy) Movement = CameraDummy.transform.TransformDirection(Movement);
		
		//faz o jogador rotacionar para a direção do movimento
		// !grab para ele não rotacionar enquanto agarra/empurra algo
		if(Movement.magnitude > 0 && !grab)
		{
			transform.forward = Vector3.Slerp(transform.forward, Movement, Time.deltaTime * 10);
		}
    }
	
	void FixedUpdate()
	{
		float velocity = rigid.velocity.magnitude;
		
		//
		rigid.AddForce((Movement * moveForce) / (velocity * speedLimiterMult + speedLimiterPlus));
	}
	
	public void ChangeState(PlayerState thisState)//função para facilitar a mudança de estados
	{
		State = thisState;
		StartCoroutine(State.ToString());
	}
	
	//jogador parado
	IEnumerator Idle()
	{
		while (State == PlayerState.Idle)
		{
			yield return new WaitForFixedUpdate();
			
			if(rigid.velocity.magnitude > 0.1f)
			{
				ChangeState(PlayerState.Walk);
			}
		}
	}
	
	//jogador andando
	IEnumerator Walk()
	{
		while (State == PlayerState.Walk)
		{
			yield return new WaitForFixedUpdate();
			if(rigid.velocity.magnitude < 0.1f)
			{
				ChangeState(PlayerState.Idle);
			}
		}
	}
}
