using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster : MonoBehaviour {
	public GameObject monster;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			
			monster.transform.position = new Vector3((float)transform.position.x, (float)monster.transform.position.y -1f);
		}
		else if(Input.GetKeyDown(KeyCode.UpArrow)){
			monster.transform.position = new Vector3((float)transform.position.x, (float)monster.transform.position.y +1f);
		}
		else if(Input.GetKeyDown(KeyCode.LeftArrow)){
			monster.transform.position = new Vector3((float)transform.position.x-1f,(float) monster.transform.position.y );
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow)){
			monster.transform.position = new Vector3((float)transform.position.x+1f,(float) monster.transform.position.y );
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.LeftArrow)){
			monster.transform.position = new Vector3((float)transform.position.x-1f,(float) monster.transform.position.y+1f );

		}
		else if(Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.RightArrow)){
			monster.transform.position = new Vector3((float)transform.position.x+1f, (float)monster.transform.position.y-1f );

		}
		else if(Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.RightArrow)){
			monster.transform.position = new Vector3((float)transform.position.x+1f, (float)monster.transform.position.y+1f );


		}

		else if(Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.LeftArrow)){
			monster.transform.position = new Vector3((float)transform.position.x-1f,(float) monster.transform.position.y+1f );


		}

	}
}
