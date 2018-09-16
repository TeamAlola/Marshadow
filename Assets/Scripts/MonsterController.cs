    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    private Animator anim_monster;
    private Rigidbody2D body;
    private bool isrotate;
    private Monstre mob;
    private AudioSource deathsound;
    public AudioClip[] sfx;

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
        deathsound = GetComponent<AudioSource>();
        deathsound.clip = sfx[0];
    }

    private void Update()
    {
        Vector2 positionV2 = new Vector2(this.transform.position.x, this.transform.position.y);
        moveRight(positionV2);
    }

    private void moveRight(Vector2 posV2)
    {
        body.MovePosition(posV2 - Vector2.left * 0.05f);
     
    }
    public void MobMeurs()
    {
        anim_monster.SetTrigger("dead");
        anim_monster.SetInteger("direction",-1);
        deathsound.Play();
        Mob.Mourir();
      
        Destroy(gameObject,deathsound.clip.length);
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
                MobMeurs();

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


}
