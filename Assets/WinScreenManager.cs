using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public void GoToMainScreen()
    {
        SceneManager.LoadScene(0);
    }
}
