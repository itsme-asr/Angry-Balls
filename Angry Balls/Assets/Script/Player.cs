using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    private bool isPressed = false;
    [SerializeField] private float releaseTime = .15f;
    void Update()
    {
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
    }
}
