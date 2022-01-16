using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameMenu;
    private static bool isGamePaused = false;

    public static bool IsGamePaused
    { 
        get => isGamePaused;
    }

    private float lastTimeScale;

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(!IsGamePaused)
            {
                gameMenu.SetActive(true);
                PuaseGame();
            }
            else
            {
                gameMenu.SetActive(false);
                ResumeGame();   
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PuaseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isGamePaused = true;
        lastTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isGamePaused = false;
        Time.timeScale = lastTimeScale;
    }
}
