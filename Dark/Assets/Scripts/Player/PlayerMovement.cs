using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 3f;

    private Rigidbody rb;
    private Vector3 movement;

    private new Transform camera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        camera = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), rb.velocity.y, Input.GetAxisRaw("Vertical")) * moveSpeed;
        rb.velocity = movement;

        transform.eulerAngles += Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        camera.eulerAngles += new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X")) * mouseSensitivity;
    }
}
