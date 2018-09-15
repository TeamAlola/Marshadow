using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    [Header("HUD")]
    public TextMeshProUGUI timer;
    public TextMeshProUGUI pv;
    public TextMeshProUGUI argent;
    public TextMeshProUGUI gameOverText;
    public HUD hud;

    [Header("GameObjects")]
    public GameObject minion;
    public GameObject spawn;
    public GameObject Tour;
    public GameObject achatMenu;
    public Grille grille;

    [Header("Donnée")]
    public int nbvague;
    public int numerovague;

    public Joueur joueur;
    public List<Monstre> monstres;
    public List<Tour> toursAchetables;
    public List<Tour> toursAchetees;
    public static GameManager gameManager;

    private Grille.Case case1; 

    public bool isspawn;
    //fait apparaitre un minion de la liste sur la map

    public void AcheterTour(int tour)
    {
        Debug.Log(case1.type);
        if (case1.type == Grille.typeCase.constructible)
        {
            Tour t = new Tour(10, 10);
            if(joueur.argent >= t.valeur)
            {
                joueur.PerdreArgent(t.valeur);
                Tour newTower = new Tour(t.valeur, t.Degat);
                toursAchetees.Add(newTower);

                //Debug.Log(case1.worldPos);

                GameObject nouvTour = Instantiate(Tour, case1.worldPos, Quaternion.identity);
                nouvTour.GetComponent<Test_de_merde>().Tower = newTower;

                grille.BuildOn(case1, newTower);

            }
        }
        else
        {
            Debug.Log("can't buy");
        }
    }

    public void Gagner()
    {
        gameOverText.text = "Félicitation, vous avez remporté ElementalTD \n Appuyez sur n'importe quel bouton pour accéder au menu";
        gameOverText.GetComponent<CanvasGroup>().alpha = 1;
        Time.timeScale = 0f;
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void Perdre()
    {
        gameOverText.text = "Malheuresement, vous puvez la mort a ElementalTD \n Appuyez sur 'r' pour recommencer ou n'importe quel autre bouton pour accéder au menu";
        gameOverText.GetComponent<CanvasGroup>().alpha = 1;
        Time.timeScale = 0f;
        if (Input.GetKeyUp(KeyCode.R))
        {
            Time.timeScale = 1f;
            Start();
        }
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Menu");
        }
    }


    // Use this for initialization
    void Start () {
        
        if (!gameManager) { gameManager = this; }
        Tour zero = new Tour(50, 1);
        Tour one = new Tour(100, 3);
        Tour two = new Tour(200, 8);
        hud = new HUD();
        nbvague = 5;
        numerovague = 0;
        joueur = new Joueur(10, 50);
        monstres = new List<Monstre>();
        toursAchetables = new List<Tour> { zero, one, two };
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
}
