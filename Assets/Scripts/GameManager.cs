using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class GameManager : MonoBehaviour {

    public TextMeshProUGUI timer;
    public TextMeshProUGUI pv;
    public TextMeshProUGUI argent;
    public GameObject achatMenu;
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

    //Vérifie que le joueur a assez d'argent, déduit l'argent puis ajoute la tour aux tours achetées
    public void AcheterTour(int tour)
    {
        Tour t = toursAchetables.ElementAtOrDefault(tour);
        if (joueur.argent >= t.valeur)
        {
            joueur.PerdreArgent(t.valeur);
            toursAchetees.Add(new Tour(t.valeur, t.degat));
        }
        else
        {
            Debug.Log("T'es pauvre gros PD");
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
        Tour zero = new Tour(50, 1);
        Tour one = new Tour(100, 3);
        Tour two = new Tour(200, 8);
        nbvague = 2;
        numerovague = 1;
        joueur = new Joueur(10, 50);
        monstres = new List<Monstre>();
        toursAchetables = new List<Tour> { zero, one, two };
        toursAchetees = new List<Tour>();      
        monstres.Add(new Monstre(1,1,1));
        monstres.Add(new Monstre(1, 1, 1));      
        toursAchetables.Add(new Tour(1, 1));        

	}


    // Update is called once per frame
    void Update () {
		
	}
}
