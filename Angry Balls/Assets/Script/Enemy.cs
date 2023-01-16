using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health = 4f;
    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
