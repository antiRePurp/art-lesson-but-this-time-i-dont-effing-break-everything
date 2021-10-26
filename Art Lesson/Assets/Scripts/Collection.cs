using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    // Particle effect to be used
    public GameObject reward;

    private void OnTriggerEnter2D(Collider2D collision) {
        // Test if trigger works
        Debug.Log("Something");
        // Instantiate/show particle effect
        Instantiate(reward, transform.position, transform.rotation);
        // Destroy the original game object
        Destroy(gameObject);
    }
}
