using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesScript : MonoBehaviour
{
    /// <summary>
    /// Move and play the partial animation
    /// </summary>
    /// <param name="position">Where to play the animation</param>
    /// <param name="color">The particals color</param>
    public void Play(Vector3 position, Color color)
    {
        GetComponent<ParticleSystem>().startColor = color;
        transform.position = position;
        GetComponent<ParticleSystem>().Play();
    }
}
