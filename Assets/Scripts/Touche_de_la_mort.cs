using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touche_de_la_mort : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touche MORTELLE");
        collision.gameObject.GetComponent<MonsterController>().Mob.InfligerDegats();
        collision.gameObject.GetComponent<MonsterController>().Mob.Mourir();
        Destroy(gameObject);
    }
}
