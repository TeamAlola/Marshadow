using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

    Rigidbody2D truc;

    Vector2 vitesse;

    public float damage;

    float existance = 0;

    // Use this for initialization
    public void Autre () {
        truc = this.GetComponent<Rigidbody2D>();
        truc.AddForce(vitesse);        
	}
	
    public void SetVitesse(Vector2 vitesseInit) {
        vitesse = vitesseInit;
    }
    public void SetDamage(float power)
    {
        damage = power;
    }

    public float GetDamage()
    {
        return damage;
    }

    public void Update()
    {
        existance = existance + Time.deltaTime;
        if (existance > 2.5) { Destroy(gameObject); }

    }

    
}
