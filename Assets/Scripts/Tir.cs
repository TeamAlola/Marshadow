using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

    Rigidbody2D truc;
    private GameObject tourparent;
    private RaycastHit2D target;
    public int damage;
    float forceEffetModif;
    float dureeEffetModif;
    Vector2 vitesse;
    float existance = 0;
    public effet effect;
    public enum effet { feu, eau, air, terre };

    private void Start() {
        truc = this.GetComponent<Rigidbody2D>();
    }
	

    public void setData(Vector2 vitesse, int power, float force,effet element ,float time, RaycastHit2D target)
    {
        SetVitesse(vitesse);
        SetDamage(power);
        SetForce(force);
        SetEffet(element);
        SetDuree(time);
        setTarget(target);

    }
    

    public void SetVitesse(Vector2 vitesseInit) {
        vitesse = vitesseInit;
    }
    public void SetDamage(int power)
    {
        damage = power;
    }
    public void setTarget(RaycastHit2D tar)
    {
        target = tar;
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

    public void SetEffet (effet element)
    {
        effect = element;
    }

    public effet GetEffet()
    {
        return effect;
    }

    public void Update()
    {
        existance = existance + Time.deltaTime;
        if (existance > 2.5 || !target) { Destroy(gameObject); }
        else{
        transform.position = Vector3.MoveTowards(transform.position,target.transform.position,Time.deltaTime*7f);
        }
    }



    
}
