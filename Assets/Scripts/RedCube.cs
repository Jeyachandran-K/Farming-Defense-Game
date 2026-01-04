using UnityEngine;

public class RedCube : MonoBehaviour
{
    [SerializeField] private float acceleration;
    private Rigidbody redCubeRigidbody;

    private void Awake()
    {
        redCubeRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 force =  Vector3.forward * (acceleration * Time.fixedDeltaTime);
        redCubeRigidbody.MovePosition(redCubeRigidbody.position + force);
    }
}
