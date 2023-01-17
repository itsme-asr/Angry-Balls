using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathEffect;
    private float health = 3f;
    public static int EnemiesAlive = 0;
    [SerializeField] AudioSource deathAudio;
    void Start()
    {
        EnemiesAlive++;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.relativeVelocity.magnitude > health)
        {
            deathAudio.Play();
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        EnemiesAlive--;

        Destroy(gameObject);
        if (EnemiesAlive <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
