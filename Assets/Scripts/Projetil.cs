using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {


	public float velocidade = 30f;
	public float tempoDestruir = 5f;

	// Use this for initialization
	void Start () {
		StartCoroutine (Destruir());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * velocidade * Time.deltaTime);
	}

	IEnumerator Destruir(){
		yield return new WaitForSeconds (tempoDestruir);
		Destroy (gameObject);
	}

	void OnCollisionEnter(Collision c){
		Destroy (gameObject);
	}
}
