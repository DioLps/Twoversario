using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    public static bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            isPaused = true;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
