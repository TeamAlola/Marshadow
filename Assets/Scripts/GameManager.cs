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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
