using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre
{

    int degat;
    int or;
    private int pv;
    private int pvmax;
    public enum element { feu, eau, air, terre,neutre };
    public element elem;
    float vitesse = 1;
    int regen = 0;
    private int dot;
    private int dureedot;
    private int dureevit;
    private float modifvit=1; 
    MonsterController monstrecontroller;

    int truc = (int)element.feu; 

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

    public float Vitesse
    {
        get
        {
            return vitesse;
        }

        set
        {
            vitesse = value;
        }
    }

    public void Update()
    {
       RegenPV();
        ApplyDot();
        if(dureevit >= 1)
        {
            dureevit--;
            if(dureevit == 0)
            {
                SetSpeedData(1, 0);
            }
        }
    }
    public void SetSpeedData(float modif, int duree)
    {
        modifvit = modif;
        dureevit = duree;
    }

    public void SetDotData(int dmg, int duree)
    {
        dot = dmg;
        dureedot = duree;
        BuffSpeed();
    }

    /// <param name="d">degat</param>
    /// <param name="o">or</param>
    /// <param name="p">pv</param>
    public Monstre(int dmg, int gold, int life,element element)
    {
       degat = dmg;
        or = gold;
        Pv = life;
        pvmax = life;
        elem = element;
    }

    //Le joueur gagne les gold du monstre, le monstre est supprimé de la liste de monstres.
    //Une nouvelle vague est lancée si il n'y a plus de monstre et encore des vagues. Sinon le joueur gagne s'il n'y a plus de vague.
    public void Mourir()
    {
        monstrecontroller.MobMeurs();
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
            if (GameManager.gameManager.nbvague >= GameManager.gameManager.numerovague) { GameManager.gameManager.hud.ResetTimer(); GameManager.gameManager.NextVague(); }
        }

    }

    public void setController(MonsterController mc)
    {
        monstrecontroller = mc;
    }

   
    public void ModifPV(int p)
    {

        this.Pv += p;
        if (Pv <= 0)
        {
            Mourir();
            monstrecontroller.MobMeurs();
        }
        if (Pv > pvmax)
        {
            Pv = pvmax;
        }
    }

    public void RegenPV()
    {
        Pv += regen;

        if (Pv >= pvmax)
        {
            Pv = pvmax;
        }

    }
    public void ApplyDot()
    {
        if (dureedot > 0)
        {
            Pv -= dot;

            if (Pv <= 0)
            {
                Mourir();
            }
            dureedot--;
        }
    }

    public void BuffSpeed()
    {
        Vitesse *= modifvit;
    }
    //meurs dot controller test vie

    public Monstre CloneMonstre()
    {
        return new Monstre(degat, or, pv, elem);
    }
}
