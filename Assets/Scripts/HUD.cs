using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    private int temps; // facilite pour afficher en secondes
    private static bool b;
    public static float time; // calcul du temps actuel du niveau, considere qu'il commence a 20

	// Use this for initialization
	void Start () {
        ResetTimer();
    }
	
	// Update is called once per frame
	void Update () {
        TimerUpdate();
    }

    void TimerUpdate()
    {
        time -= Time.deltaTime;
        Debug.Log(b);
        if (time > 0f)
        {
            GameManager.gameManager.timer.GetComponent<CanvasGroup>().alpha = 1;
            GameManager.gameManager.achatMenu.GetComponent<CanvasGroup>().alpha = 1;
            GameManager.gameManager.timer.text = ((int)time).ToString();
        }
        else
        {
            GameManager.gameManager.timer.text = "C'est parti !";
            GameManager.gameManager.achatMenu.GetComponent<CanvasGroup>().alpha = 0;
            if ((int)time <= -3 && !b)
            {
                GameManager.gameManager.numerovague++;
                GameManager.gameManager.timer.GetComponent<CanvasGroup>().alpha = 0;
                Monstre mobCree = new Monstre(1, 1, 1);
                GameManager.gameManager.monstres.Add(mobCree);
                GameObject mobInst = Instantiate(GameManager.gameManager.minion, GameManager.gameManager.spawn.transform.position, GameManager.gameManager.spawn.transform.rotation);
                mobInst.GetComponent<MonsterController>().Mob = mobCree;
                b = true;
                Debug.Log("nouveau monstre");
            }
        }
    }

    public void ResetTimer()
    {
        time = 5f;
        temps = 4;
        b = false;
    }

    public void PrintLives(int vies)
    {
        GameManager.gameManager.pv.text = vies + " Vies";
    }

    public void PrintMoney(int argent)
    {
        GameManager.gameManager.argent.text = argent + " $";
    }
}
