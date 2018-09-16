using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directions : MonoBehaviour {

    public MonsterController.Direction direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hey");
        if (collision.gameObject.tag == "Ennemy")
        {
            collision.gameObject.GetComponent<MonsterController>().setDirection(direction);
        }
    }




}
