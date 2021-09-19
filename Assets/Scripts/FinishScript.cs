using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    public GameObject finishImage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            finishImage.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
