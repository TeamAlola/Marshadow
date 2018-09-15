using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    public TextMeshProUGUI timer;
    public TextMeshProUGUI pvetargent;
    public Joueur joueur;
    public List<Monstre> monstres;
    public List<Tour> toursAchetables;
    public List<Tour> toursAchetees;
    public int nbvague;
    public int numerovague;
    public GameObject minion;
    public GameObject spawn;
    public static GameManager gameManager;

    //fait apparaitre un minion de la liste sur la map
    public void Spawn()
    {
        Instantiate(minion,spawn.transform.position,spawn.transform.rotation);
    }

    public void NewVague(int i)
    {
        numerovague++;
        for(int j = 0; i<30; i ++)
        {
            monstres.Add(new Monstre(i, i+1/2, i));
        }
        float time=0f;
        float temps=0f;

        time += Time.deltaTime;
        while (time < monstres.Count)
        {
            if (time >= temps)
            {
                GameManager.gameManager.Spawn();
                Debug.Log("Un minion a spawn");
                temps++;
            }
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

    public void InitGameData()
    {
        nbvague = 2;
        numerovague = 1;
        joueur = new Joueur(10, 50);
        monstres = new List<Monstre>();
        toursAchetables = new List<Tour>();
        toursAchetees = new List<Tour>();
        toursAchetables.Add(new Tour(1, 1));
    }

    // Use this for initialization
    void Start () {

        if (!gameManager) { gameManager = this; }

        InitGameData();
        //quand timer fini
        NewVague(numerovague);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
