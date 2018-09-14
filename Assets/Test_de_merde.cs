using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_de_merde : MonoBehaviour {

   private RaycastHit2D item;
    private float timerFire = 0;
    public GameObject Balle;

	
	// Update is called once per frame
	void Update () {
        timerFire = timerFire + Time.deltaTime;
        if (timerFire > 3)
        {
            item = Physics2D.CircleCast(this.transform.position, 10, Vector2.zero);
            if (item)
            {
                Debug.Log("ENNEMI EN VUE");
                Debug.Log(item.point);
                GameObject projectil = Instantiate(Balle, this.transform);
                projectil.GetComponent<tir>().SetVitesse(new Vector2(item.transform.position.x-this.transform.position.x, 
                    item.transform.position.y-this.transform.position.y).normalized*150);
                projectil.GetComponent<tir>().Autre();
            }
            else
            {
                Debug.Log("JE VOIS RIEN!!!!");
            }
            timerFire = 0;
        }
	}
}
