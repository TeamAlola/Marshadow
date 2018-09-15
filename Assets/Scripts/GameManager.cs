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

    public static GameManager gameManager;

    public void NewVague()
    {
        numerovague++;
        for(int i = 0; i<30; i ++)
        {
            monstres.Add(new Monstre(1, 1, 1));
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
        nbvague = 2;
        numerovague = 1;
        joueur = new Joueur(10, 50);
        monstres = new List<Monstre>();
        toursAchetables = new List<Tour>();
        toursAchetees = new List<Tour>();      
        monstres.Add(new Monstre(1,1,1));
        monstres.Add(new Monstre(1, 1, 1));      
        toursAchetables.Add(new Tour(1, 1));        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
