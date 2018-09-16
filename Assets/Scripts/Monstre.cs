using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre
{

    int degat;
    int or;
    private int pv;
    private int pvmax;
    public enum element { feu, eau, air, terre };
    float vitesse = 1;
    int regen = 0;
    private int dot;
    private int dureedot;
    MonsterController monstrecontroller;

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

    public int Dot
    {
        get
        {
            return dot;
        }
    }

    public void SetDotData(int dmg, int duree)
    {
        dot = dmg;
        dureedot = duree;
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
        Debug.Log("faire mourir le mob");
        GameManager.gameManager.joueur.GagnerArgent(or);
        GameManager.gameManager.monstres.Remove(this);
        if (GameManager.gameManager.monstres.Count == 0)
        {
            if (GameManager.gameManager.nbvague >= GameManager.gameManager.numerovague) { GameManager.gameManager.hud.ResetTimer(); }
        }
    }

    //Inflige les degats au joueur et supprime le monstre de la liste.
    //Une nouvelle vague est lancée si il n'y a plus de monstre et encore des vagues. Sinon le joueur gagne s'il n'y a plus de vague.
    public void InfligerDegats()
    {
        Debug.Log("faire mourir le mob");
        GameManager.gameManager.joueur.PrendreDegats(degat);
        GameManager.gameManager.monstres.Remove(this);
        if (GameManager.gameManager.monstres.Count == 0)
        {
            if (GameManager.gameManager.nbvague >= GameManager.gameManager.numerovague) { GameManager.gameManager.hud.ResetTimer(); }
        }

    }

    public void setController(MonsterController mc)
    {
        monstrecontroller = mc;
    }

    public void ModifPV(int pv)
    {
        this.pv += pv;
        if (pv <= 0)
        {
            Mourir();
        }
        if (pv > pvmax)
        {
            pv = pvmax;
        }
    }

    public void RegenPV()
    {
        pv += regen;

        if (pv >= pvmax)
        {
            pv = pvmax;
        }

    }
    public void ApplyDot()
    {
        if (dureedot > 0)
        {
            pv -= dot;

            if (pv <= 0)
            {
                Mourir();
            }
            dureedot--;
        }
    }

    public void BuffSpeed(float vitesse)
    {
        this.vitesse *= vitesse;
    }
    //meurs dot controller test vie

}
