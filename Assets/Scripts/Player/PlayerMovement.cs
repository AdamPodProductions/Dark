using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    [Range(1, 10)]
    public float mouseSensitivity = 3f;

    private bool canMove = true;
    public bool CanMove { get { return canMove; } set { canMove = value; } }

    [SerializeField]
    private RadarDisplay radarDisplay;

    [Space]

    [SerializeField]
    private AudioClip[] footstepSounds;
    private AudioSource audioSource;
    private float footstepTimer = 0f;

    private Vector3 movement;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        radarDisplay.AddBlip(transform, Color.green);
    }

    private void Update()
    {
        if (CanMove)
        {
            Movement();
            MouseLook();
            CheckFootstep();
        }
    }

    private void Movement()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void MouseLook()
    {
        transform.eulerAngles += Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity;
    }

    private void PlayFootstepSound()
    {
        int index = Random.Range(0, footstepSounds.Length);
        audioSource.PlayOneShot(footstepSounds[index]);
    }

    private void CheckFootstep()
    {
        if (!movement.Equals(Vector3.zero))
        {
            footstepTimer -= Time.deltaTime;

            if (footstepTimer < 0)
            {
                PlayFootstepSound();
                footstepTimer = 0.4f;
            }
        }
    }
}
