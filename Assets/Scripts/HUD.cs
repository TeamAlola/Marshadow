﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HUD : MonoBehaviour {

    private static int temps; // facilite pour afficher en secondes
    private static bool b;
    private static float time; // calcul du temps actuel du niveau, considere qu'il commence a 20
    private static int counter;
    private static bool musiclaunched;
    private AudioSource launchsound;

    public AudioClip[] sfx;

    // Use this for initialization
    void Start () {
        launchsound = GetComponent<AudioSource>();
        launchsound.clip = sfx[0];
        musiclaunched = false;
    }
	
	// Update is called once per frame
	void Update () {
        TimerUpdate();
    }

    void TimerUpdate()
    {
        time -= Time.deltaTime;
        if (time > 0f)
        {
            GameManager.gameManager.timer.gameObject.SetActive(true);
            GameManager.gameManager.timer.text = ((int)time).ToString();
        }
        else
        {
            
            GameManager.gameManager.timer.text = "C'est parti !";
            if (!musiclaunched && (int)time == 0)
            {
                musiclaunched = true;
                launchsound.Play();
            }
            GameManager.gameManager.achatMenu.GetComponent<CanvasGroup>().alpha = 0;
            if (!b && (int)time == -2 )
            {
                
                GameManager.gameManager.numerovague++;
                for (int i = 0; i < 10; i++)
                {
                    GameManager.gameManager.monstres.Add(new Monstre(100, 100, 100,Monstre.element.feu));
                }
                b = true;
            }
        }
    }

    public void ResetTimer()
    {
        time = 10f;
        temps = -4;
        counter = 0;
        b = false;
    }

    public void PrintLives(int vies)
    {
        GameManager.gameManager.pv.text = vies.ToString();
    }

    public void PrintMoney(int argent)
    {
        GameManager.gameManager.argent.text = argent.ToString();
    }
}
