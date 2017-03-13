using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

	public GameObject projetil;
	public float intervalo;
	bool atirar = true;

	void Update () {
		if (Input.GetButton ("Jump") && atirar) {
			Instantiate (projetil, transform.position, transform.rotation);
			atirar = false;
			StartCoroutine (podeAtirar (intervalo));
		}
	}

	IEnumerator podeAtirar(float t){
		yield return new WaitForSeconds (t);
		atirar = true;
	}
}
