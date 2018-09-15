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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            logo.GetComponent<CanvasGroup>().alpha = 0;
            menu.GetComponent<CanvasGroup>().alpha = 1;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Sample Scene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
