﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grille : MonoBehaviour
{

    public Tilemap grille;
    public Sprite constructible;
    public Sprite route;
    public Sprite decor;
      

    public enum typeCase { constructible, construit, route, decor };

    public class Case
    {
        public int posx;
        public int posy;

        public typeCase type;

        public Tour tower;

        public Case(int px, int py)
        {
            posx = px;
            posy = py;
        }


    }
    private List<Case> listCase;


    private void Start()
    { 
        Debug.Log(grille.origin + " / " + grille.size);

        listCase = new List<Case>();

        for (int i = grille.origin.x; i < grille.origin.x + grille.size.x -1; i++)
        {
            for (int j = grille.origin.y; j < grille.origin.y + grille.size.y -1; j++)
            {
                Case c = new Case(i, j);
                c.type = grille.GetTile(new Vector3Int(i, j, 0)).name == constructible.name ? typeCase.constructible :
                   grille.GetTile(new Vector3Int(i, j, 0)).name == route.name ? typeCase.route : typeCase.decor;
              
                listCase.Add(c);
            }
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(getCase().type);
        }
    }
    
    public Case getCase()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        Vector3Int position = grille.WorldToCell(worldPoint);
        Case ca = listCase.Find(x => x.posx == position.x && x.posy == position.y);
        return ca;
    }

    public Case BuildOn(Case ca, Tour tower)
    {
        Case provisoir = listCase.Find(x => x.posx == ca.posx && x.posy == ca.posy);
        if (ca.type == typeCase.constructible)
        {
            provisoir.tower = tower;
            provisoir.type = typeCase.construit;
        }
        return provisoir;

    }


}