using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseController : MonoBehaviour {


    public Tilemap tiles;
    public Tile tile;

    public Vector3 vec;

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3Int vecc = new Vector3Int((int)vec.x, (int)vec.y, 0);
            tiles.SetTile(vecc, tile);

        }
    }


}
