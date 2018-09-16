    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    private Animator anim_monster;
    private Rigidbody2D body;
    private bool isrotate;
    private Monstre mob;

    public enum Direction { Up, Down, Left, Right, Stop};

    private Direction direction = Direction.Stop;

    public Monstre Mob
    {
        get
        {
            return mob;
        }

        set
        {
            mob = value;
        }
    }

    public int GetPv()
    {
        return Mob.Pv;
    }
        

    private void Start()
    {
        anim_monster = this.GetComponent<Animator>();
        body = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 positionV2 = new Vector2(this.transform.position.x, this.transform.position.y);
        switch (direction)
        {
            case Direction.Up:
                moveUp(positionV2);
                break;
            case Direction.Down:
                movedown(positionV2);
                break;
            case Direction.Left:
                moveLeft(positionV2);
                break;
            case Direction.Right:
                moveRight(positionV2);
                break;
            case Direction.Stop:
                break;
        }
    }

    private void moveRight(Vector2 posV2)
    {
        body.MovePosition(posV2 - Vector2.left * 0.05f);
    }
    private void moveLeft(Vector2 posV2)
    {
        body.MovePosition(posV2 + Vector2.left * 0.05f);
    }
    private void moveUp(Vector2 posV2)
    {
        body.MovePosition(posV2 + Vector2.up * 0.05f);
    }
    private void movedown(Vector2 posV2)
    {
        body.MovePosition(posV2 - Vector2.up * 0.05f);
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.tag.Equals("Indestructible"))
        {
            Debug.Log("Touche");
            int PV = GetPv();
            Destroy(collision.gameObject);
            int damage;
            
            PV = PV - collision.gameObject.GetComponent<Tir>().GetDamage();
            if (PV <= 0)
                Mob.Mourir();
            Destroy(gameObject);

           switch (collision.gameObject.GetComponent<Tir>().effect){

                case Tir.effet.feu:

                    break;

                case Tir.effet.eau:
                    break;

                case Tir.effet.air:
                    break;

                case Tir.effet.terre:
                    break;

            }

        }
    }

    public void setDirection(Direction dir)
    {
        direction = dir;
    }


}
