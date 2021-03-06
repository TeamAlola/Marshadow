﻿using System.Collections;
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

    public bool isDead;

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
            mob.Update();
            timer = 0;

        }
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
        body.MovePosition((posV2 - Vector2.left * 0.05f) * Mob.Vitesse);
        anim_monster.SetInteger("direction", 2);
        isrotate = true;
        this.GetComponent<SpriteRenderer>().flipX = true;
    }
    private void moveLeft(Vector2 posV2)
    {
        body.MovePosition((posV2 + Vector2.left * 0.05f) * Mob.Vitesse);
        if (isrotate)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            isrotate = false;
        }
        anim_monster.SetInteger("direction", 6);
    }
    private void moveUp(Vector2 posV2)
    {
        body.MovePosition((posV2 + Vector2.up * 0.05f) * Mob.Vitesse);
        if (isrotate)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            isrotate = false;
        }
        anim_monster.SetInteger("direction", 8);
    }
    private void movedown(Vector2 posV2)
    {
        body.MovePosition((posV2 - Vector2.up * 0.05f) * Mob.Vitesse);
        if (isrotate)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            isrotate = false;
        }
        anim_monster.SetInteger("direction", 4);
    }


    public void MobMeurs()
    {
        isDead = true;
        direction = Direction.Stop;
        anim_monster.SetTrigger("dead");
        anim_monster.SetInteger("direction", -1);
        deathsound.Play();

        Destroy(gameObject, deathsound.clip.length);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead)
        {
            return;
        }
        if (!collision.transform.tag.Equals("Indestructible"))
        {
            Tir proj = collision.gameObject.GetComponent<Tir>();

            float modif = GameManager.gameManager.gameData.eTab[(int)proj.effect, (int)mob.elem];
            mob.ModifPV(-(int)(proj.GetDamage()*modif));

            if (proj.effect.Equals(Monstre.element.terre))
            {
                RaycastHit2D[] tabTarget = Physics2D.CircleCastAll(this.transform.position, 2, Vector2.zero);
                foreach (RaycastHit2D t in tabTarget)
                {
                    if (t.collider.gameObject.tag == "Ennemy")
                    {
                        t.collider.gameObject.GetComponent<MonsterController>().mob.ModifPV(-proj.GetDamage());
                    }
                }
            }
            else if (proj.effect.Equals(Monstre.element.feu))
            {
                mob.SetDotData(1, 3);
            }
            Destroy(collision.gameObject);

        }
    }

    public void setDirection(Direction dir)
    {
        direction = dir;
    }

    [ContextMenu("afficherpv")]
    public void AfficherPV()
    {
        Debug.Log(mob.Pv);
    }

}
