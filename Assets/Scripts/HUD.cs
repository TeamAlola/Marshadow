using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    private float temps;
    private float time;

	// Use this for initialization
	void Start () {
        ResetTimer();
	}
	
	// Update is called once per frame
	void Update () {
        TimerUpdate();
        GameManager.gameManager.pvetargent.text = GameManager.gameManager.joueur.pv + " Vies \n" + GameManager.gameManager.joueur.argent + " $";
    }

    void TimerUpdate()
    {
        time -= Time.deltaTime;
        if (time > 0f)
        {
            GameManager.gameManager.timer.GetComponent<CanvasGroup>().alpha = 1;
            if (time < temps)
            {
                GameManager.gameManager.timer.text = temps.ToString();
                temps--;
            }
        }
        else
        {
            GameManager.gameManager.timer.text = "C'est parti !";
            if(time < -3f)
            {
                GameManager.gameManager.timer.GetComponent<CanvasGroup>().alpha = 0;
            }
        }
    }

    public void ResetTimer()
    {
        time = 20f;
        temps = 19f;
    }
}
