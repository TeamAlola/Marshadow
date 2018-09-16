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
    private float delais=1f;
    public float timer;

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
    }

    private void Update()
    {
        Vector2 positionV2 = new Vector2(this.transform.position.x, this.transform.position.y);
        moveRight(positionV2);
        timer += Time.deltaTime;
        if (timer > delais)
        {
            mob.ApplyDot();
            mob.RegenPV();
            timer = 0;
        }
    }

    private void moveRight(Vector2 posV2)
    {
        body.MovePosition(posV2 - Vector2.left * 0.05f);
        anim_monster.SetInteger("direction", 2);
        isrotate = true;
        this.GetComponent<SpriteRenderer>().flipX = true;
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
                mob.SetDotData(1,10);
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }



}
