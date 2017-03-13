using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {


	public float velocidade = 30f;
	public float tempoDestruir = 5f;
	public GameObject particles;

	Renderer rend;

	// Use this for initialization
	void Start () {
		StartCoroutine (Destruir());
		rend = GetComponent<Renderer> ();

		rend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * velocidade * Time.deltaTime);
	}

	IEnumerator Destruir(){
		yield return new WaitForSeconds (tempoDestruir);
		Destroy (gameObject);
	}

	void OnCollisionEnter(Collision c){
		Instantiate (particles, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
