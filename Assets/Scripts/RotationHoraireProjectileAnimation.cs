using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHoraireProjectileAnimation : MonoBehaviour {
	private float angle;
	public GameObject rb;
	
	
	// Update is called once per frame
	void Update () {
		angle+=400*Time.deltaTime;
     rb.transform.eulerAngles = new Vector3(0,0,-angle);
	}
}
