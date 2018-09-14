using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Joueur joueur;
    public List<Monstre> monstres;
    public List<Tour> toursAchetables;
    public List<Tour> toursAchetees;

    public static GameManager gameManager;
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
        joueur = new Joueur(10, 5);
        monstres = new List<Monstre>();
        toursAchetables = new List<Tour>();
        toursAchetees = new List<Tour>();      
        monstres.Add(new Monstre(1,5,5));
        monstres.Add(new Monstre(1, 10, 10));      
        toursAchetables.Add(new Tour(3, 2));        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
