using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    /// <summary>
    /// The Parent Object of all the the end game UI elements
    /// </summary>
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
