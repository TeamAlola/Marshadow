using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestInteraction : MonoBehaviour {

    [ContextMenu("MonstreMeurs")]
    public void MonstreMeurs()
    {
        GameManager.gameManager.monstres.First().Mourir();
        Debug.Log("Monstre mort");
        Debug.Log("vague: " + GameManager.gameManager.numerovague);
        Debug.Log("pv joueur: " + GameManager.gameManager.joueur.pv);
        Debug.Log("or joueur: " + GameManager.gameManager.joueur.argent);
        Debug.Log("nb monstres: " + GameManager.gameManager.monstres.Count);
        Debug.Log("tours possédées: " + GameManager.gameManager.toursAchetees.Count);
    }

    [ContextMenu("MonstreSurvit")]
    public void MonstreSurvit()
    {
        GameManager.gameManager.monstres.ElementAt(0).InfligerDegats();
        Debug.Log("Monstre survivant");
        Debug.Log("vague: " + GameManager.gameManager.numerovague);
        Debug.Log("pv joueur: " + GameManager.gameManager.joueur.pv);
        Debug.Log("or joueur: " + GameManager.gameManager.joueur.argent);
        Debug.Log("nb monstres: " + GameManager.gameManager.monstres.Count);
        Debug.Log("tours possédées: " + GameManager.gameManager.toursAchetees.Count);
    }

    [ContextMenu("JoueurAchete")]
    public void JoueurAchete()
    {
        Debug.Log("tours achetables: " + GameManager.gameManager.toursAchetables.Count);
        Tour t1= GameManager.gameManager.toursAchetables.ElementAt(0);
        GameManager.gameManager.AcheterTour(0);
        Debug.Log("Tour achetée");
        Debug.Log("vague: " + GameManager.gameManager.numerovague);
        Debug.Log("pv joueur: " + GameManager.gameManager.joueur.pv);
        Debug.Log("or joueur: " + GameManager.gameManager.joueur.argent);
        Debug.Log("nb monstres: " + GameManager.gameManager.monstres.Count);
        Debug.Log("tours possédées: " + GameManager.gameManager.toursAchetees.Count);
    }


    [ContextMenu("RevendreTour")]
    public void RevendreTour()
    {
        GameManager.gameManager.toursAchetees.ElementAt(0).Revendre();
        Debug.Log("Tour revendu");
        Debug.Log("vague: " + GameManager.gameManager.numerovague);
        Debug.Log("pv joueur: " + GameManager.gameManager.joueur.pv);
        Debug.Log("or joueur: " + GameManager.gameManager.joueur.argent);
        Debug.Log("nb monstres: " + GameManager.gameManager.monstres.Count);
        Debug.Log("tours possédées: " + GameManager.gameManager.toursAchetees.Count);
    }


    [ContextMenu("AcheterTour")]
    public void AcheterTour()
    {
        GameManager.gameManager.AcheterTour(0);
    }


}
