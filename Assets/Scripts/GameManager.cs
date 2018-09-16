﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {



    [Header("HUD")]
    public TextMeshProUGUI timer;
    public TextMeshProUGUI pv;
    public TextMeshProUGUI argent;
    public TextMeshProUGUI gameOverText;
    public GameObject pausePanel;
    public Button resume;
    public Button quit;
    public HUD hud;
    public Sprite fireoff, iceoff, neutraloff, naturaloff, windoff, fireon, iceon, neutralon, naturalon, windon;

    [Header("GameObjects")]
    public GameObject minion;
    public GameObject spawn;
    public GameObject Tour;
    public GameObject camera;

    public GameObject achatMenu;
    public Grille grille;
    [Header("Donnée")]
    public int nbvague;
    public int numerovague;
    public Joueur joueur;
    public List<Monstre> monstres;
    public List<Tour> toursAchetables;
    public List<Tour> toursAchetees;
    public GameObject[] alltowers;
    public static GameManager gameManager;
    public AudioClip[] sfx;
    public GameData gameData;

    private AudioSource mainmusic;
    
    private Grille.Case case1; 
    private AudioSource sound;
    private bool musiclaunch;


    public bool isSpawn;
    //fait apparaitre un minion de la liste sur la map

    private int currentVague;
    private bool spawning;
    private float spawnTimer;
    public float spawnDelai = 1f;

    public void AcheterTour(int tour)
    {
        Debug.Log(case1.type);
        if (case1.type == Grille.typeCase.constructible)
        { 
            
            Tour t = new Tour(toursAchetables.ElementAt(tour).valeur, toursAchetables.ElementAt(tour).Degat, toursAchetables.ElementAt(tour).forceEffetModif, toursAchetables.ElementAt(tour).dureeEffetModif, toursAchetables.ElementAt(tour).vitesse, toursAchetables.ElementAt(tour).element,toursAchetables.ElementAt(tour).prefabtower);
            if(joueur.argent >= t.valeur)
            {
                joueur.PerdreArgent(t.valeur);
                Tour newTower = new Tour(t.valeur, t.Degat, t.forceEffetModif, t.dureeEffetModif,t.vitesse,t.element,t.prefabtower);
                toursAchetees.Add(newTower);

                //Debug.Log(case1.worldPos);

                GameObject nouvTour = Instantiate(alltowers[tour], case1.worldPos, Quaternion.identity);
                nouvTour.GetComponent<Test_de_merde>().Tower = newTower;

                grille.BuildOn(case1, newTower);
                sound.time = 0.6f;
                sound.Play();

            }
        }
        else
        {
            Debug.Log("can't buy");
        }
    }

    public void UpgradeTower(){
        if (case1.type == Grille.typeCase.construit){
            if(joueur.argent >= 5* (case1.tower.niv/2))
            {
            joueur.PerdreArgent(5* (case1.tower.niv/2));
            Tour current = case1.tower;

            current.Upgrade();
            }
        }
    }

    public void Gagner()
    {
        pausePanel.GetComponent<CanvasGroup>().alpha = 1;
        gameOverText.text = "Félicitation, vous avez remporté ElementalTD \n Appuyez sur n'importe quel bouton pour accéder au menu";
        if(!musiclaunch){
        musiclaunch = true;
        camera.GetComponent<AudioSource>().Stop();
        sound.clip = sfx[1];
        sound.Play();
        }
        
        gameOverText.GetComponent<CanvasGroup>().alpha = 1;
        Time.timeScale = 0f;
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
    }

    public void Perdre()
    {
        pausePanel.GetComponent<CanvasGroup>().alpha = 1;
        gameOverText.text = "Malheuresement, vous puez la mort a ElementalTD \n Appuyez sur n'importe quel bouton pour accéder au menu";
        gameOverText.GetComponent<CanvasGroup>().alpha = 1;
        Time.timeScale = 0f;
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
    }

    public void Pause()
    {
        pausePanel.GetComponent<CanvasGroup>().alpha = 1;
        resume.GetComponent<CanvasGroup>().alpha = 1;
        quit.GetComponent<CanvasGroup>().alpha = 1;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pausePanel.GetComponent<CanvasGroup>().alpha = 0;
        resume.GetComponent<CanvasGroup>().alpha = 0;
        quit.GetComponent<CanvasGroup>().alpha = 0;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Use this for initialization
    void Start () {
        
        if (!gameManager) { gameManager = this; }
        Tour neutral = new Tour(10, 1,0f,0f,new Vector2(1,1), Monstre.element.neutre,alltowers[0]);
        Tour fire = new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.feu,alltowers[1]);
        Tour ice = new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.eau,alltowers[4]);
        Tour nature = new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.terre,alltowers[2]);
        Tour wind = new Tour(10, 1, 0f, 0f, new Vector2(1, 1), Monstre.element.air,alltowers[3]);

        hud = new HUD();
        nbvague = 5;
        numerovague = 0;
        sound = GetComponent<AudioSource>();
        sound.clip = sfx[0];
        joueur = new Joueur(10, 50);
        monstres = new List<Monstre>();
        toursAchetables = new List<Tour> { neutral, fire, ice, nature, wind };
        toursAchetees = new List<Tour>();
        hud.ResetTimer();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            case1 = grille.getCase(); //case actuelle
            if(case1.type == Grille.typeCase.construit)
            {
                SelectTower();
            }
            if(case1.type == Grille.typeCase.constructible)
            {
                BuyTower();
            }
        }

        if (numerovague == nbvague && !monstres.Any())
        {
            Gagner();
        }
        if (joueur.pv == 0)
        {
            Perdre();
        }
        if (isSpawn)
        {
            spawnTimer += Time.deltaTime;
            if(spawnTimer > spawnDelai)
            {

                spawnTimer = 0;
            }
        }
    }

    public void SelectTower()
    {
        Tour tower = case1.tower;
        Debug.Log("Tour selectionnée");
    }

    public void BuyTower()
    {
        Debug.Log("Acheter une tour");
    }

    public void StartVague(int i)
    {
        isSpawn = true;
        spawnTimer = 0;

    }
    public void finVague()
    {
        isSpawn = false;
        currentVague++;
    }

    public void NextMob()
    {
        Vague.MonstreObjet toSpawn = gameData.vague[0].nextMonstre();
        timer.gameObject.SetActive(false);
        monstres.Add(toSpawn.monstre);
        GameObject mobInst = Instantiate(toSpawn.go, spawn.transform.position, spawn.transform.rotation);
        mobInst.GetComponent<MonsterController>().Mob = toSpawn.monstre;

    }

}
