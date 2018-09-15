using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

    Rigidbody2D truc;

    Vector2 vitesse;

	// Use this for initialization
	public void Autre () {
        truc = this.GetComponent<Rigidbody2D>();
        truc.AddForce(vitesse);        
	}
	
    public void SetVitesse(Vector2 vitesseInit) {
        vitesse = vitesseInit;
    }
}
