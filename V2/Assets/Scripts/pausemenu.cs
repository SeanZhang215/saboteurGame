using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    private bool menukeys = true;
    public GameObject pauseMenuUI;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (menukeys)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenuUI.SetActive(true);
                menukeys = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuUI.SetActive(false);
            menukeys = true;
        }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        menukeys = true;
    }
    public void Quit()
    {
        Application.Quit();

    }
    public void Mainmenu()
    {

        SceneManager.LoadScene("IntroMenu");
    }
    public void Playagain()
    {

        SceneManager.LoadScene("MainScene");
    }
}

