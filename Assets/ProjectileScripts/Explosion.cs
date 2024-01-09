using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float force, radius, modifier;

    // Particle system prefab
    public GameObject explosionFX;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate the explosion particle system when this
        // GameObject is created.
        Instantiate(explosionFX, transform.position, Quaternion.identity);

        // Destroy explosion after 0.1 seconds
        Invoke("DestroyExplosion", 0.1f);
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody)
        {
            rigidbody.AddExplosionForce(force, transform.position, radius, modifier,ForceMode.VelocityChange);
        }
    }

    void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
