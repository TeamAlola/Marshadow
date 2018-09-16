using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class MonsterController : MonoBehaviour
{

    private Animator anim_monster;
    private Rigidbody2D body;
    private bool isrotate;
    private Monstre mob;

    private float delais = 1f;
    public float timer;
    private AudioSource deathsound;
    public AudioClip[] sfx;

    public enum Direction { Up, Down, Left, Right, Stop };

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
            mob.setController(this);
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
        deathsound = GetComponent<AudioSource>();
        deathsound.clip = sfx[0];
    }

    private void Update()
    {
        Vector2 positionV2 = new Vector2(this.transform.position.x, this.transform.position.y);
        timer += Time.deltaTime;
        if (timer > delais)
        {
            mob.ApplyDot();
            mob.RegenPV();
            timer = 0;
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


    public void MobMeurs()
    {
        anim_monster.SetTrigger("dead");
        anim_monster.SetInteger("direction", -1);
        deathsound.Play();
        Mob.Mourir();

        Destroy(gameObject, deathsound.clip.length);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.tag.Equals("Indestructible"))
        {
            Debug.Log("Touche");
            mob.ModifPV(-collision.gameObject.GetComponent<Tir>().GetDamage());
            //aoe terre
            if (collision.gameObject.GetComponent<Tir>().effect.Equals(Tir.effet.terre))
            {
                //propager le tir autour
            }
            else if (collision.gameObject.GetComponent<Tir>().effect.Equals(Tir.effet.feu))
            {
                mob.SetDotData(1, 10);
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
            

        }
    }

    public void setDirection(Direction dir)
    {
        direction = dir;
    }



}
