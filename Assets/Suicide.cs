using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touche");
         Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
