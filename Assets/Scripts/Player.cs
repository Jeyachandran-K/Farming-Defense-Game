using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]private float playerMovementSpeed;
    [SerializeField]private Transform cameraPivot;
    [SerializeField] private float xSensitivity;
    [SerializeField] private float ySensitivity;
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;

    private Rigidbody playerRigidbody;
    private Vector2 mousePosition;
    private bool isCursorLocked = false;

    private float yaw;
    private float pitch;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        LockCursor();
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("escape is pressed");
            if (isCursorLocked)
            {
                UnLockCursor();
            }
            else
            {
                LockCursor();
            }
        }
        mousePosition = Mouse.current.delta.ReadValue();

        yaw += mousePosition.x*xSensitivity*Time.deltaTime;
        pitch -= mousePosition.y*ySensitivity*Time.deltaTime;

        transform.Rotate(Vector3.up*yaw);

        pitch =Mathf.Clamp(pitch, minPitch, maxPitch);
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);

    }

    private void FixedUpdate()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            playerRigidbody.AddForce(transform.forward * playerMovementSpeed);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            playerRigidbody.AddForce(-transform.forward * playerMovementSpeed);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            playerRigidbody.AddForce(transform.right * playerMovementSpeed);
        }
        if (Keyboard.current.aKey.isPressed)
        {
            playerRigidbody.AddForce(-transform.right * playerMovementSpeed);
        }
    }
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isCursorLocked = true;
    }
    private void UnLockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCursorLocked = false;
    }
}
