using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyController : MonoBehaviour {



    public tileCollider tiles;
    public Vector2Int position;

    public enum direction { none, up, down, left, right };

    public direction direct;
    private Rigidbody2D body;
     public Vector2 startPoint;

    private void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Vector2 posV2 = new Vector2(transform.position.x, transform.position.y);
        
        if(direct == direction.up && tiles.hasUp(position.x, position.y)){
            body.MovePosition(posV2 + Vector2.up * 0.1f);
        }
        if(direct == direction.left && tiles.hasLeft(position.x,    position.y))
        {
            body.MovePosition(posV2 +  Vector2.left * 0.1f);
        }
        if (direct == direction.down && tiles.hasDown(position.x, position.y))
        {
            body.MovePosition(posV2 -Vector2.up * 0.1f);
        }
        if (direct == direction.right && tiles.hasRight(position.x, position.y))
        {
            body.MovePosition( posV2 -Vector2.left * 0.1f);
        }

    }



}
