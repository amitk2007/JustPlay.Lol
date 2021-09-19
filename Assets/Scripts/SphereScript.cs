using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.staticParticleSystem.Play(transform.position, Color.red);
        Destroy(this.gameObject);
    }
}
