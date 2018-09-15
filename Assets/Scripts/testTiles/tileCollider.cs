using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tileCollider : MonoBehaviour {

    private const int x = -10;
    private const int y = -5;

    public Tilemap tiles;
    public Tile tileRed;

    public Case start;
    public Case end;

    public class Case
    {
        public int x;
        public int y;
        public Case nextCase;
        public Case previousCase;

        public Case(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void setNextCase(Case c)
        {
            nextCase = c;
        }
        public void setPreviousCase(Case c)
        {
            previousCase = c;
        }
    }


    public int[,] tableau = new int[Mathf.Abs(x)*2 , Mathf.Abs(y) * 2];
    //public List<Case> tableau = new List<Case>();


    public void Start()
    {

        for (int i = 0; i < Mathf.Abs(x) * 2; i++)
        {
            for (int j = 0; j < Mathf.Abs(y) * 2; j++)
            {
                tableau[i, j] = tiles.HasTile(new Vector3Int(i + x, j + y, 0)) ? 1 : 0;
                //Case current = new Case(new Vector2(i,j));
                //tableau.Add(current);

            }
        }
    }

    public bool hasUp(int x, int y)
    {
        return tableau[x, y + 1] == 1;
    }
    public bool hasDown(int x, int y)
    {
        return tableau[x, y - 1] == 1;
    }
    public bool hasRight(int x, int y)
    {
        return tableau[x - 1, y] == 1;
    }

    public bool hasLeft(int x, int y)
    {
        return tableau[x + 1, y] == 1;
    }


}
