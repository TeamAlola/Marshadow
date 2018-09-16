using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class Grille : MonoBehaviour
{

    public Tilemap grille;
    public Sprite constructible;
    public Sprite route;
    public Sprite decor;

    private Case current;

    public enum typeCase { constructible, construit, route, decor, none };

    public class Case
    {
        public int posx;
        public int posy;

        public typeCase type;

        public Tour tower;
        public Vector3 worldPos;

        public Case(int px, int py)
        {
            posx = px;
            posy = py;
        }
        public Case()
        {
            type = typeCase.none;
        }


    }
    private List<Case> listCase;


    private void Start()
    {
        Debug.Log(grille.origin + " / " + grille.size);

        listCase = new List<Case>();
        listCase.Add(new Case());

        for (int i = grille.origin.x; i < grille.origin.x + grille.size.x -1; i++)
        {
            for (int j = grille.origin.y; j < grille.origin.y + grille.size.y -1; j++)
            {
                Case c = new Case(i, j);
                if(grille.GetTile(new Vector3Int(i, j, 0)))
                {
                    c.type = grille.GetTile(new Vector3Int(i, j, 0)).name == constructible.name ? typeCase.constructible :
                  grille.GetTile(new Vector3Int(i, j, 0)).name == route.name ? typeCase.route : typeCase.decor;

                    c.worldPos = grille.CellToWorld(new Vector3Int(i, j, 0));

                    c.worldPos += grille.cellSize / 2;

                    //Debug.Log(c.worldPos);

                    listCase.Add(c);
                }
               
            }
        }
        Debug.Log(listCase.Count);
    }
    
    
    public Case getCase()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return current;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        Vector3Int position = grille.WorldToCell(worldPoint);
        Case ca = listCase.Find(x => x.posx == position.x && x.posy == position.y);
        current = ca;
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