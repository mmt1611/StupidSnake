﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtcleEfct : MonoBehaviour {

	public Transform boom;
	ParticleSystem cheese;
	ParticleSystem.EmissionModule em;
	 
	// Use this for initialization
	void Start () {
		cheese = boom.GetComponent<ParticleSystem> ();
		em = cheese.emission;
		em.enabled = false;
	}

	void OnCollisionEnter2D(Collision2D collision){		
		if (collision.gameObject.name == "Player") {
			GetComponent<PolygonCollider2D> ().enabled = false;
            GetComponent<AudioSource>().Play();
			em.enabled = true;
			GetComponent<Renderer> ().enabled = false;
			//ScoreManager.currentscore++;
			StartCoroutine (StopBoom());
		}
	}

	IEnumerator StopBoom() {
		yield return new WaitForSeconds(0.8f);
		em.enabled = false;
		Destroy(this.gameObject);
	}
}
