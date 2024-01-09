using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    public GameObject explosion;

    // When this GameObject collides with another.
    void OnCollisionEnter(Collision collision)
    {
        // If other GameObject is ground.
        if (collision.gameObject.CompareTag("Ground"))
        {
            Score score = FindObjectOfType<Score>();
            if (score)
            {
                score.EndLevel();
            }

            if (explosion){
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);   
            }
        }
    }
}
