using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorEnemy : MonoBehaviour {

	public GameObject enemy;
	public GameObject particulaExplosao;
	public float velocidade = 5f;
	public int vidaInicial, vidaFinal;
	int vida;

	void Start () {
		vida = Random.Range (vidaInicial, vidaFinal);
	}

	void Update () {
		transform.Translate (Vector3.right * velocidade * Time.deltaTime);

		if (vida <= 0) {
			DestruirRobo ();
		}
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Projetil") {
			vida--;
		}

		if(c.gameObject.tag == "Player"){
			DestruirRobo ();
		}
	}

	void DestruirRobo(){
		Instantiate (particulaExplosao, enemy.transform.position, enemy.transform.rotation);
		Destroy (gameObject);
	}
}
