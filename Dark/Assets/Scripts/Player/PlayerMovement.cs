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

    public GameObject isSprintingImage;
    public Image staminaBar;

    private float speedMultiplier;
    private bool sprinting;
    private Vector3 movement;

    private new Transform camera;

    private void Start()
    {
        speedMultiplier = moveSpeed;

        camera = Camera.main.transform;
    }

    private void Update()
    {
        if (CanMove)
        {
            CheckSprint();
            Movement();

            MouseLook();
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
        camera.eulerAngles += new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X")) * mouseSensitivity;
    }
}
