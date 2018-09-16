using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Vague X", menuName = "Data/Vague")]
public class Vague : ScriptableObject{

    [CreateAssetMenu (fileName = "Monstre", menuName = "Data/Monstre")]
    public class MonstreData : ScriptableObject 
    {
        public int pv;
        public int dmg;
        public int or;
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
    }

    public List<ContenueVague> Contenu;
    public bool randomiser;

    //public  List<MonstreObjet> GenerateVague()
    //{
    //    List<MonstreObjet> retour = new List<MonstreObjet>();
    //    for(int i = 0; i < )
    //}



}
