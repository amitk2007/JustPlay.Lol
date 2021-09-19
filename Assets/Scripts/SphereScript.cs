using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    // Destory Sphere and play parical animation
    private void OnMouseDown()
    {
        GameManager.staticParticleSystem.Play(transform.position, Color.red);
        Destroy(this.gameObject);
    }
}
