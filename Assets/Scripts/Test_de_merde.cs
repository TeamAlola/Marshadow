using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Test_de_merde : MonoBehaviour {
    private RaycastHit2D targetULTIME;
    private RaycastHit2D item;
    private RaycastHit2D[] tabTarget;
    private float timerFire = 0;
    public GameObject Balle;
    private float rangeDetect = 12;
    private Tour tower;
    private Animator ou;


    public RaycastHit2D GetItem (){
        return targetULTIME;
    }

    public RaycastHit2D[] GetTabtarget (){
        return tabTarget;
    }
    public Tour Tower
    {
        get
        {
            return tower;
        }

        set
        {
            tower = value;
        }
    }

    //Animation d'upgrade
    public void Upgrade()
    {
        
    }

    public int GetDegat ()
    {
        return Tower.Degat;
    }
    

    private void Start()
    {
        ou = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        timerFire = timerFire + Time.deltaTime;
       
        tabTarget = Physics2D.CircleCastAll(this.transform.position, rangeDetect, Vector2.zero);
        if (tabTarget.Length != 0) item = ProxyTarget(tabTarget);
        //Tir toute les deux secondes
        if (timerFire > 3)
        {
            //Si cible trouve
            if (item)
            {                  
                GameObject projectil = Instantiate(Balle, this.transform);
                projectil.GetComponent<Tir>().SetVitesse(new Vector2(item.transform.position.x - this.transform.position.x,
                    item.transform.position.y - this.transform.position.y).normalized * 250);
                projectil.GetComponent<Tir>().setData(Vector2.zero, tower.Degat, tower.forceEffetModif,tower.element,tower.dureeEffetModif, item);
               
                item = Physics2D.CircleCast(this.transform.position, 0, Vector2.zero);
            }
            
            timerFire = 0;
        }
	}

    RaycastHit2D ProxyTarget(RaycastHit2D[] tabTarget)
    {
        int indmin = 0;
        int compteur = 0;
        Vector2 min = Vector2.positiveInfinity;
        Vector2 verif;
        foreach(RaycastHit2D vec in tabTarget)
        {
            verif = new Vector2(vec.transform.position.x - this.transform.position.x, vec.transform.position.y - this.transform.position.y);
            if (min.magnitude > verif.magnitude && tabTarget[compteur].transform.tag.Equals("Ennemy"))
            {
                indmin = compteur;
                min = verif;
            }
            compteur++;
        }
        if (tabTarget[indmin].transform.tag.Equals("Ennemy")){
            targetULTIME = tabTarget[indmin];
            return tabTarget[indmin];
        }
        else
        {
            return item = new RaycastHit2D();
        }
    }

}
