using System.Collections;
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
    public List<Tour> toursAchetees;
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
    public List<Vague> vagues;

    public void AcheterTour(int tour)
    {
        Debug.Log(case1.type);
        if (case1.type == Grille.typeCase.constructible)
        {
            Tour t = GameData.toursAchetables.ElementAt(tour).CloneTour();
            if(joueur.argent >= t.valeur)
            {
                joueur.PerdreArgent(t.valeur);
                Tour newTower = new Tour(t.valeur, t.Degat, t.forceEffetModif, t.dureeEffetModif,t.vitesse,t.element,t.prefabtower);
                toursAchetees.Add(newTower);
                
                GameObject nouvTour = Instantiate(t.prefabtower, case1.worldPos, Quaternion.identity);
                nouvTour.GetComponent<Test_de_merde>().Tower = newTower;

                grille.BuildOn(case1, newTower);
                sound.clip = sfx[0];
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
            sound.clip = sfx[3];
            sound.Play();
            joueur.PerdreArgent(5* (case1.tower.niv/2));
            Tour current = case1.tower;

            current.Upgrade();

            }
        }
    }

    public void Gagner()
    {
        pausePanel.SetActive(true);
        resume.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        gameOverText.text = "Félicitation, vous avez remporté Elemental TD \n Appuyez sur n'importe quel bouton pour acceder au menu";
        if(!musiclaunch){
        musiclaunch = true;
        camera.GetComponent<AudioSource>().Stop();
        sound.clip = sfx[1];
        sound.Play();
        }
        Time.timeScale = 0f;
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
    }

    public void Perdre()
    {
<<<<<<< HEAD
        pausePanel.SetActive(true);
        resume.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        quit.gameObject.SetActive(false);
        gameOverText.text = "Malheuresement, vous puez la mort a ElementalTD \n Appuyez sur n'importe quel bouton pour acceder au menu";
=======
        pausePanel.GetComponent<CanvasGroup>().alpha = 1;
        gameOverText.text = "Malheuresement, vous puez la mort a ElementalTD \n Appuyez sur n'importe quel bouton pour accéder au menu";
        gameOverText.GetComponent<CanvasGroup>().alpha = 1;
        if(!musiclaunch){
        musiclaunch = true;
        camera.GetComponent<AudioSource>().Stop();
        sound.clip = sfx[2];
        sound.Play();
        }
>>>>>>> bf8a89d0fabe6d5c0ff619373ef66dfec3b81ed5
        Time.timeScale = 0f;
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        resume.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Use this for initialization
    void Start () {
        
        if (!gameManager) { gameManager = this; }
        hud = new HUD();
        nbvague = 5;
        numerovague = 0;
        sound = GetComponent<AudioSource>();
        joueur = new Joueur(10, 50);
        monstres = new List<Monstre>();
        toursAchetees = new List<Tour>();
        hud.ResetTimer();
        StartVague(0);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && grille != null && grille.getCase() != null )
        {
            case1 = grille.getCase(); //case actuelle
            if (case1.type == Grille.typeCase.construit)
            {
                SelectTower();
            }
            if (case1.type == Grille.typeCase.constructible)
            {
                BuyTower();
            }
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
                NextMob();
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
        vagues[i].init();
        isSpawn = true;
        spawnTimer = 0;

    }
    public void finVague()
    {
        isSpawn = false;
        currentVague++;
        if(currentVague > vagues.Count)
        {
            Gagner();
        }
    }

   public void NextVague()
    {
        StartVague(currentVague);
    }
    
    public void NextMob()
    {
        Vague.MonstreObjet toSpawn = vagues[currentVague].nextMonstre();
        if (toSpawn == null)
        {
            finVague();
            return;
        }
        timer.gameObject.SetActive(false);
        GameObject mobInst = Instantiate(toSpawn.go, spawn.transform.position, spawn.transform.rotation);
        mobInst.GetComponent<MonsterController>().Mob = toSpawn.monstre;

    }
    
}
