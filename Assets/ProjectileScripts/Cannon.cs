using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Animator animator;
    public Transform fireSocket;
    public float rotationRate = 90.0f;
    public ParticleSystem fireFX;

    public int numProjectiles = 0;

    // Update is called once per frame
    void Update()
    {
        float aimInput = Input.GetAxis("Horizontal");
        aimInput *= rotationRate * Time.deltaTime;
        transform.Rotate(Vector3.right * aimInput, Space.Self);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        animator.SetTrigger("Fire");
        // Instantiate a new projectile
        Instantiate(projectilePrefab, fireSocket.position, fireSocket.rotation);
        // Play fire particle system
        fireFX.Play();
        numProjectiles++;
    }
}
