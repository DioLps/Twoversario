using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void onClickStartGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void onClickBonus()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(2);
    }
    public void onClickExit()
    {
        Application.Quit();
    }
}
