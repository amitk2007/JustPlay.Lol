using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(nameof(CollectablesTags.Coin))|| other.CompareTag(nameof(CollectablesTags.Crystal)))
        {
            GameManager.AddPoints(other.tag);
            GameManager.staticParticleSystem.Play(transform.position, Color.cyan);
            Destroy(other.gameObject);
        }
    }
}
