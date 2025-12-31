using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float sensitivity;

    private CharacterController playerCharacterController;
    private InputSystem_Actions input;
    private Vector2 keyboardInput;
    private Vector2 mouseInput;
    private float mouseInputX;
    private float mouseInputY;

    public event EventHandler OnSeeingSoilShop;

    private void Awake()
    {
        Instance = this;
        playerCharacterController = GetComponent<CharacterController>();
        input = new InputSystem_Actions();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void Update()
    {


        keyboardInput = input.Player.Move.ReadValue<Vector2>();
       
        Vector3 move = (transform.right * keyboardInput.x + transform.forward * keyboardInput.y).normalized;

        playerCharacterController.Move(move * Time.deltaTime * playerMovementSpeed);
        DetectShop();
       
    }
    private void LateUpdate()
    {
        
        mouseInput = input.Player.Look.ReadValue<Vector2>();
        if (mouseInput.sqrMagnitude > 0.01f)
        {
            mouseInputX = mouseInput.x * sensitivity;
            mouseInputY += -mouseInput.y * sensitivity;
            mouseInputY = Mathf.Clamp(mouseInputY, -90, 90);

            cameraPivot.transform.localRotation = Quaternion.Euler(mouseInputY, 0, 0);

            transform.Rotate(Vector3.up * mouseInputX);
        }
       
    }
    public void DetectShop()
    {
        float playerHeight = 2f;
        float playerRadius = 0.5f;
        float maxDistance = 2f;
        if(Physics.CapsuleCast(transform.position, transform.position + new Vector3(0,playerHeight,0), playerRadius, transform.forward,out RaycastHit raycastHit,maxDistance))
        {
            if(raycastHit.collider.TryGetComponent<SoilShop>(out SoilShop soilShop))
            {
                OnSeeingSoilShop?.Invoke(this,EventArgs.Empty);
            }
        }
    }
}
