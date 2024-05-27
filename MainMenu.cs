using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public static bool newGame = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void PlayButtonNewGame()
    {
        newGame = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void QuitButtonTitle() 
    {
        Application.Quit();
    }
    public void QuitButtonMenu() 
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SaveHandler>().Save();
        Application.Quit();
    }
}
