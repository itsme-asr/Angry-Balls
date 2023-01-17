using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Rigidbody2D hook;
    [SerializeField] GameObject nextBall;
    [SerializeField] AudioSource stringEffect;
    private bool isPressed = false;
    [SerializeField] private float releaseTime = .15f;

    [SerializeField] private float maxDragDistance = 2f;
    void Update()
    {
        if (isPressed)
        {

            Vector2 mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mosPos, hook.position) > maxDragDistance)
            {
                rb.position = hook.position + (mosPos - hook.position).normalized * maxDragDistance;

            }
            else
                rb.position = mosPos;
        }

    }

    private void OnMouseDown() // drag
    {
        stringEffect.Play();
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp() // release
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(release());

    }

    IEnumerator release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(1f);


        Destroy(gameObject, 3.5f);

        if (nextBall != null)
        {
            nextBall.SetActive(true);
        }
        else
        {
            Enemy.EnemiesAlive = 0;
            Invoke("restart", 1f);
        }
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
