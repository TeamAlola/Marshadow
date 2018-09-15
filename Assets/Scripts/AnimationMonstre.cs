using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMonstre : MonoBehaviour {
	public GameObject monster;
	private float pos_x;
	private float pos_y;
	private bool isrotate;
	private int i = 0;
	private Animator anim_monster;
	// Use this for initialization
	void Start () {
	anim_monster = monster.transform.GetComponent<Animator>();
	pos_x = this.transform.position.x;
	pos_y = this.transform.position.y;
	isrotate = false;
	}
	
	// Update is called once per frame
	void Update () {
		

		// Droite
		if(pos_x < this.transform.position.x && pos_y == this.transform.position.y){
			anim_monster.SetInteger("direction", 2);
			isrotate = true;
			monster.GetComponent<SpriteRenderer>().flipX = true;
		}
		// Gauche
		else if(pos_x > this.transform.position.x && pos_y == this.transform.position.y){
			if(isrotate){
				monster.GetComponent<SpriteRenderer>().flipX = false;
				isrotate = false;
			}
			anim_monster.SetInteger("direction", 6);
		}
		// Haut
		else if(pos_x == this.transform.position.x && pos_y < this.transform.position.y){
			if(isrotate){
				monster.GetComponent<SpriteRenderer>().flipX = false;
				isrotate = false;
			}
			anim_monster.SetInteger("direction", 8);
		}
		// Bas
		else if(pos_x == this.transform.position.x && pos_y > this.transform.position.y){
			if(isrotate){
				monster.GetComponent<SpriteRenderer>().flipX = false;
				isrotate = false;
			}
			anim_monster.SetInteger("direction", 4);
		}
		
		
			pos_x = this.transform.position.x;
			pos_y = this.transform.position.y;
	}
	
}
