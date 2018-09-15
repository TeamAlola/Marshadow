using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

    Rigidbody2D truc;


    public int damage;
    float forceEffetModif;
    float dureeEffetModif;
    Vector2 vitesse;
    float existance = 0;
    public effet effect;
    public enum effet { feu, eau, air, terre };

    // Use this for initialization
    public void Autre () {
        truc = this.GetComponent<Rigidbody2D>();
        truc.AddForce(vitesse);        
	}
	
    public void SetVitesse(Vector2 vitesseInit) {
        vitesse = vitesseInit;
    }
    public void SetDamage(int power)
    {
        damage = power;
    }

    public int GetDamage()
    {
        return damage;
    }
    public void SetForce(float power)
    {
        forceEffetModif = power;
    }

    public float GetForce()
    {
        return forceEffetModif;
    }
    public void SetDuree(float power)
    {
        dureeEffetModif = power;
    }

    public float GetDuree()
    {
        return dureeEffetModif;
    }
    public void Update()
    {
        existance = existance + Time.deltaTime;
        if (existance > 2.5) { Destroy(gameObject); }

    }



    
}
