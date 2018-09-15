using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    public TextMeshProUGUI timer;
    public TextMeshProUGUI pv;
    public TextMeshProUGUI argent;
    public Joueur joueur;
    public HUD hud;
    public List<Monstre> monstres;
    public List<Tour> toursAchetables;
    public List<Tour> toursAchetees;
    public int nbvague;
    public int numerovague;
    public GameObject minion;
    public GameObject spawn;
    public static GameManager gameManager;
    public bool isspawn;
    //fait apparaitre un minion de la liste sur la map
  

    public IEnumerator NewVague()
    {
        while (true)
        {
            if (isspawn)
            {
                Debug.Log("nouvelle vague");
                numerovague++;
                for (int j = 0; j < 10; j++)
                {
                    monstres.Add(new Monstre(1, 1, 1));
                }
                for (int k = 0; k < 10; k++)
                {
                    Instantiate(minion, spawn.transform.position, spawn.transform.rotation);
                    yield return new WaitForSeconds(1f);
                }
                isspawn = false;
            }
            yield return null;
        }
    }

    public void Gagner()
    {
        Debug.Log("T'as un gros zizi!");
    }

    public void Perdre()
    {

        Debug.Log("Tu pus");
    }


    // Use this for initialization
    void Start () {

        if (!gameManager) { gameManager = this; }
        isspawn = false;
        nbvague = 2;
        numerovague = 1;
        joueur = new Joueur(10, 50);
        monstres = new List<Monstre>();
        toursAchetables = new List<Tour>();
        toursAchetees = new List<Tour>();
        toursAchetables.Add(new Tour(1, 1));
        //quand timer fini
        StartCoroutine(NewVague());
        

    }
	
	// Update is called once per frame
	void Update () {
	}
}
