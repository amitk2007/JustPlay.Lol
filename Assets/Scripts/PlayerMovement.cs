using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidbody;
    Animator animator;

    GameObject touchingSphere;

    [SerializeField]
    float speed = 5f;

    float horizontalInput;
    [SerializeField]
    float horizontalSpeed = 10f;
    [SerializeField]
    float minX;
    [SerializeField]
    float maxX;

    [SerializeField]
    float jumpForce = 250f;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rigidbody.velocity = Vector3.forward * speed;
    }

    void Update()
    {
        HorizontalMovement();
        Jump();
        MaintainVelocity();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpForce);
        }
    }

    void HorizontalMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime);
        KeepInBounds();
    }
    void KeepInBounds()
    {
        float xInBounds = Mathf.Clamp(transform.position.x, minX, maxX);
        this.transform.position = new Vector3(xInBounds, transform.position.y, transform.position.z);
    }

    void MaintainVelocity()
    {
        if (rigidbody.velocity.magnitude < speed && touchingSphere == null)
        {
            animator.SetBool("IsRuning", true);
            rigidbody.velocity = Vector3.forward * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Sphere"))
        {
            rigidbody.velocity = Vector3.zero;
            touchingSphere = collision.gameObject;
            animator.SetBool("IsRuning", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Sphere"))
        {
            touchingSphere = null;
        }
    }
}
