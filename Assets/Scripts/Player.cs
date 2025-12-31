using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private Transform cameraPivot;
    [SerializeField] private float sensitivity;

    private CharacterController playerCharacterController;
    private InputSystem_Actions input;
    private Vector2 keyboardInput;
    private Vector2 mouseInput;
    private float mouseInputX;

    private void Awake()
    {
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
        keyboardInput = input.Player.Move.ReadValue<Vector2>().normalized;
       
        Vector3 move = transform.right * keyboardInput.x + transform.forward * keyboardInput.y;

        playerCharacterController.Move(move*Time.deltaTime*playerMovementSpeed);

        mouseInput = input.Player.Look.ReadValue<Vector2>();
       
        mouseInputX = mouseInput.x * sensitivity;
        transform.Rotate(Vector3.up * mouseInputX);
    }
}
