using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathEffect;
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
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
