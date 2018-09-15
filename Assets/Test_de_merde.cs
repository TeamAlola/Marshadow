using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Test_de_merde : MonoBehaviour {

   private RaycastHit2D item;
    private RaycastHit2D[] tabTarget;
    private float timerFire = 0;
    public GameObject Balle;
    private float rangeDetect = 0;

	
	// Update is called once per frame
	void Update () {
        timerFire = timerFire + Time.deltaTime;
       
        tabTarget = Physics2D.CircleCastAll(this.transform.position, rangeDetect, Vector2.zero);
     
        //Tir toute les deux secondes
        if (timerFire > 2)
        {
            //Si cible trouve
            if (item)
            {
                Debug.Log("ENNEMI EN VUE");
                Debug.Log(item.point);
                GameObject projectil = Instantiate(Balle, this.transform);
                projectil.GetComponent<tir>().SetVitesse(new Vector2(item.transform.position.x-this.transform.position.x, 
                    item.transform.position.y-this.transform.position.y).normalized*150);
                projectil.GetComponent<tir>().Autre();
                
                item = Physics2D.CircleCast(this.transform.position, 0, Vector2.zero);
            }
            
            timerFire = 0;
        }
	}

    RaycastHit2D proxyTarget(RaycastHit2D[] tabTarget)
    {
        Vector2 min = Vector2.positiveInfinity;
        Vector2 verif;
        foreach(RaycastHit2D vec in tabTarget)
        {
            verif = new Vector2(vec.transform.position.x - this.transform.position.x, vec.transform.position.y - this.transform.position.y);
            if (min.magnitude > verif.magnitude) ;
        }

        return tabTarget[0];
    }

}
