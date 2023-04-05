using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomScoreManager : MonoBehaviour
{
    [SerializeField]
    private static int maxIndex = 9;

    public static int index = 0;
    private static TMP_Text textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponent<TMP_Text>();
        SetTextLabel();
    }

    public static void IncreaseIndex()
    {
        if (index < maxIndex)
        {
            index++;
            SetTextLabel();
        }

        if (index == maxIndex)
        {
            Cursor.visible = true;
            SceneManager.LoadScene(3);
        }
    }

    private static void SetTextLabel()
    {
        textMeshPro?.SetText(index + "/" + maxIndex);
    }
}
