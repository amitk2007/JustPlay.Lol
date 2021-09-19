using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesScript : MonoBehaviour
{
    public void Play(Vector3 position, Color color)
    {
        GetComponent<ParticleSystem>().startColor = color;
        transform.position = position;
        GetComponent<ParticleSystem>().Play();
    }
}
