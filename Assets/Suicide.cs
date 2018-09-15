using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour {

    private int PV = 5;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touche");

         Destroy(collision.gameObject);
        PV--;
        if(PV==0)
        Destroy(gameObject);
    }
}
