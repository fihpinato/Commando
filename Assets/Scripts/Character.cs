using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public GameObject personagem; 		//Recebe a malha 3d do personagem
	public float velocidade = 5f;
	public float forcaPulo = 5f;
	public float gravidade = 9.8f;

	Vector3 moverDirecao = Vector3.zero;

	//Interface do componente de animação
	Animation anim;

	void Start () {

		anim = personagem.GetComponent<Animation>();

		anim.CrossFade ("idle");

	}
	
	void Update () {
		Mover ();	
		ControlaAnim ();
		ControlaRotacao ();
	}

	void Mover(){
		CharacterController controller = GetComponent<CharacterController>();

		if(controller.isGrounded){

			moverDirecao = new Vector3 (Input.GetAxisRaw("Horizontal"), 0f, 0f);

			moverDirecao = transform.TransformDirection (moverDirecao) * velocidade;

		}

		/*
		if (Input.GetButtonDown ("Jump")) {
			moverDirecao.y += forcaPulo;
		}
		*/

		moverDirecao.y -= gravidade * Time.deltaTime;

		controller.Move (moverDirecao * Time.deltaTime);
	}

	void ControlaAnim(){
		if (Input.GetAxisRaw ("Horizontal") != 0f) {
			anim.CrossFade ("run");
		} else {
			anim.CrossFade ("idle");
		}

		if (Input.GetButton ("Jump") && Input.GetAxisRaw("Horizontal") == 0) {
			anim.CrossFade("fire");
		}
	}

	void ControlaRotacao(){
		if (Input.GetAxisRaw ("Horizontal") > 0f) {
			personagem.transform.rotation = Quaternion.Euler (0f, 90f, 0f);
		} else if(Input.GetAxisRaw ("Horizontal") < 0f){
			personagem.transform.rotation = Quaternion.Euler (0f, 270f, 0f);
		}
	}
}
