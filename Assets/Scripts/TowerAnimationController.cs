using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAnimationController : MonoBehaviour {
	public GameObject tower;
	private Animator toweranim;
	private SpriteRenderer towerspriterenderer;
	// Use this for initialization
	void Start () {
		toweranim = tower.GetComponent<Animator>();
		towerspriterenderer = tower.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(toweranim.GetCurrentAnimatorStateInfo(0).IsName(tower.name+"_standby")){
			towerspriterenderer.flipX = false;
		}

	}
}
