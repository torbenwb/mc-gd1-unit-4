using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float forceAmount = 15.0f;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        Vector3 forceDirection = transform.forward;

        rigidbody.AddForce(forceDirection * forceAmount, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision other)
    {
        // Is the colliding object part of the castle or part of the ground?
        if (other.gameObject.CompareTag("Castle") || other.gameObject.CompareTag("Ground"))
        {
            // Instantiate explosion prefab at projectile position
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // Destroy projectile
            Destroy(gameObject);
        }  
    }
}
