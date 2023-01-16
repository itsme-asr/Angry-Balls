using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Rigidbody2D hook;
    [SerializeField] GameObject nextBall;
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
        nextBall.SetActive(true);

        Destroy(gameObject, 2f);
    }
}
