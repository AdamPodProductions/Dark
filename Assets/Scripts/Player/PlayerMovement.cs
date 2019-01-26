using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField]
    private float stamina = 4f;
    public float Stamina { get { return stamina; } set { stamina = value; } }

    [Range(1, 10)]
    public float mouseSensitivity = 3f;

    private bool canMove = true;
    public bool CanMove { get { return canMove; } set { canMove = value; } }

    [Space]

    public GameObject isSprintingImage;
    public Image staminaBar;

    [SerializeField]
    private RadarDisplay radarDisplay;

    [Space]

    [SerializeField]
    private AudioClip[] footstepSounds;
    private AudioSource audioSource;
    private float footstepTimer = 0f;

    private float speedMultiplier = 1f;
    private bool sprinting = false;
    private Vector3 movement;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        speedMultiplier = moveSpeed;

        radarDisplay.AddBlip(transform, Color.green);
    }

    private void Update()
    {
        if (CanMove)
        {
            CheckSprint();
            Movement();

            MouseLook();

            CheckFootstep();
        }
    }

    private void ReplenishStamina()
    {
        if (Stamina < 4f)
        {
            Stamina += Time.deltaTime;
        }
    }

    private void DrainStamina()
    {
        Stamina -= Time.deltaTime;
    }

    private void Movement()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speedMultiplier * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void CheckSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = !sprinting;
            isSprintingImage.SetActive(sprinting);
        }

        if (sprinting)
        {
            if (Stamina > 0f && !movement.Equals(Vector3.zero))
            {
                speedMultiplier = 2f;
                DrainStamina();
            }
        }
        else
        {
            speedMultiplier = 1f;
            sprinting = false;
            ReplenishStamina();
        }

        staminaBar.fillAmount = Stamina / 4f;
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
            footstepTimer -= Time.deltaTime * speedMultiplier;

            if (footstepTimer < 0)
            {
                PlayFootstepSound();
                footstepTimer = 0.5f;
            }
        }
    }
}
