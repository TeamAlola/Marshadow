using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vague X", menuName = "Data/Vague")]
public class Vague : ScriptableObject
{

    [CreateAssetMenu(fileName = "Monstre", menuName = "Data/Monstre")]
    public class MonstreData : ScriptableObject
    {
        public int pv;
        public int dmg;
        public int or;
        public Monstre.element element;
        public GameObject objetMonstre;
    }

    [System.Serializable]
    public class ContenueVague
    {
        public MonstreData monstre;
        public int nombre;
    }

    public class MonstreObjet
    {
        public Monstre monstre;
        public GameObject go;
        

        public MonstreObjet(Monstre mo, GameObject g)
        {
            monstre = mo;
            go = g;
        }
    }

    public List<ContenueVague> contenu;
    private int index;
    public List<MonstreObjet> listMob;

    public void init()
    {
        listMob = GenerateVague();
    }

    public List<MonstreObjet> GenerateVague()
    {
        List<MonstreObjet> retour = new List<MonstreObjet>();
        for (int i = 0; i < contenu.Count; i++)
        {
            for (int j = 0; j < contenu[i].nombre; j++)
            {
                Monstre newMob = new Monstre(contenu[i].monstre.dmg, contenu[i].monstre.or, contenu[i].monstre.pv, contenu[i].monstre.element);
                GameManager.gameManager.monstres.Add(newMob);
                retour.Add(new MonstreObjet(newMob, contenu[i].monstre.objetMonstre));
            }
        }

        return retour;
    }

    public MonstreObjet nextMonstre()
    {
        if(index > listMob.Count)
        {
            Debug.Log("trop de spawn");
            return null;
        }
        MonstreObjet retour = listMob[index];
        index++;
        return retour;
    }
}