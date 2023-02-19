using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterSomeTime : MonoBehaviour
{
    [SerializeField]
    private float secoundsToGetUnactive = 3f;

    void Start()
    {
        StartCoroutine(WaitForSeconds());
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(secoundsToGetUnactive);
        gameObject.SetActive(false);
    }
}
