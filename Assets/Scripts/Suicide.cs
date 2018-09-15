using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour {

    private float PV = 15f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touche");

         Destroy(collision.gameObject);
        PV = PV - collision.gameObject.GetComponent<Tir>().GetDamage();
        if(PV==0)
        Destroy(gameObject);
    }
}
