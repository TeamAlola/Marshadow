﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBoss : MonoBehaviour {
	public GameObject monster;
	private float pos_x;
	private float pos_y;
	
	private Animator anim_monster;
	// Use this for initialization
	void Start () {
	anim_monster = monster.transform.GetComponent<Animator>();
	pos_x = this.transform.position.x;
	pos_y = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		

		// Droite
		if(pos_x < this.transform.position.x && pos_y == this.transform.position.y){
			anim_monster.SetInteger("direction", 2);
		}
		// Gauche
		else if(pos_x > this.transform.position.x && pos_y == this.transform.position.y){
	
			anim_monster.SetInteger("direction", 6);

		}
		// Haut
		else if(pos_x == this.transform.position.x && pos_y < this.transform.position.y){
		
			anim_monster.SetInteger("direction", 8);
		}
		// Bas
		else if(pos_x == this.transform.position.x && pos_y > this.transform.position.y){
		
			anim_monster.SetInteger("direction", 4);
		}
		
		
		else if (Input.GetKeyDown(KeyCode.Space)){
			anim_monster.SetInteger("direction", -1);

			anim_monster.SetTrigger("dead");
					

		}
			pos_x = this.transform.position.x;
			pos_y = this.transform.position.y;
	}
	
}
