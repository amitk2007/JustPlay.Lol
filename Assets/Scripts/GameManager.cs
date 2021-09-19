using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum CollectablesTags
{
    Coin = 1,
    Crystal = 10,
}

public class GameManager : MonoBehaviour
{
    public static int TotalPoints = 0;

    public Text scoreText;
    public static Text staticScoreText;

    public ParticlesScript particleSystem;
    public static ParticlesScript staticParticleSystem;

    void Awake()
    {
        Time.timeScale = 1;
        TotalPoints = 0;
        SetFloatingCollectables(nameof(CollectablesTags.Coin), nameof(CollectablesTags.Crystal));
        SetSpheres();
    }

    void Start()
    {
        staticScoreText = scoreText;
        staticScoreText.text = "Score: " + TotalPoints;
        staticParticleSystem = particleSystem;
    }

    void SetFloatingCollectables(params string[] tags)
    {
        foreach (string tag in tags)
        {
            foreach (GameObject collectable in GameObject.FindGameObjectsWithTag(tag))
            {
                collectable.AddComponent<CollectablesScript>();
            }
        }
    }
    void SetSpheres()
    {
        foreach (GameObject collectable in GameObject.FindGameObjectsWithTag("Sphere"))
        {
            collectable.AddComponent<SphereScript>();
        }
    }
    public static void AddPoints(string tagName)
    {
        CollectablesTags tag = (CollectablesTags)System.Enum.Parse(typeof(CollectablesTags), tagName);
        TotalPoints += (int)tag;
        staticScoreText.text = "Score: " + TotalPoints;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
