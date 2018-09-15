using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject menu;
    public GameObject logo;

	// Use this for initialization
	void Start ()
    {
        logo.GetComponent<CanvasGroup>().alpha = 1;
        menu.GetComponent<CanvasGroup>().alpha = 0;
    }
	
	// Update is called once per frame
	void Update () {

        // si on clique on fait apparaitre le meny
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            logo.GetComponent<CanvasGroup>().alpha = 0;
            menu.GetComponent<CanvasGroup>().alpha = 1;
        }
    }

    public void Play()
    {
        if ( menu.GetComponent<CanvasGroup>().alpha == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Quit()
    {
        if (menu.GetComponent<CanvasGroup>().alpha == 1)
        {
            Application.Quit();
        }
    }
}
