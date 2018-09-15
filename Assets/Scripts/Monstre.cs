using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre  {

    int degat;
    int or;
    private int pv;

    public int Pv
    {
        get
        {
            return pv;
        }

        set
        {
            pv = value;
        }
    }

    /// <param name="d">degat</param>
    /// <param name="o">or</param>
    /// <param name="p">pv</param>
    public Monstre(int d, int o, int p)
    {
        degat = d;
        or = o;
        Pv = p;
    }

    //Le joueur gagne les gold du monstre, le monstre est supprimé de la liste de monstres.
    //Une nouvelle vague est lancée si il n'y a plus de monstre et encore des vagues. Sinon le joueur gagne s'il n'y a plus de vague.
    public void Mourir()
    {
        GameManager.gameManager.joueur.GagnerArgent(or);
        GameManager.gameManager.monstres.Remove(this);
        if (GameManager.gameManager.monstres.Count == 0 && GameManager.gameManager.joueur.pv > 0)
        {
            if (GameManager.gameManager.nbvague >= GameManager.gameManager.numerovague) { GameManager.gameManager.hud.ResetTimer(); }
            else { GameManager.gameManager.Gagner(); }
        }
    }

    //Inflige les degats au joueur et supprime le monstre de la liste.
    //Une nouvelle vague est lancée si il n'y a plus de monstre et encore des vagues. Sinon le joueur gagne s'il n'y a plus de vague.
    public void InfligerDegats()
    {
        GameManager.gameManager.joueur.PrendreDegats(degat);
        GameManager.gameManager.monstres.Remove(this);
        if (GameManager.gameManager.monstres.Count == 0 && GameManager.gameManager.joueur.pv > 0)
        {
            if (GameManager.gameManager.nbvague >= GameManager.gameManager.numerovague) { GameManager.gameManager.hud.ResetTimer(); }
            else { GameManager.gameManager.Gagner(); }
        }
    }
}
