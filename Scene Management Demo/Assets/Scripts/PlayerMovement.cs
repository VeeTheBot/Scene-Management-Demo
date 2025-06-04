using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // The rigidbody
    private Rigidbody2D body;
    // The player controls
    private InputSystem_Actions playerControls;
    // Reference to the movement input action
    private InputAction movement;

    // The movement speed
    [SerializeField] private float speed = 7f;

    private void Awake()
    {
        // Fetch the rigidbody
        body = GetComponent<Rigidbody2D>();

        // Fetch new player controls
        playerControls = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        movement = playerControls.Player.Move;
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Adjust the movement speed accordingly
        Vector2 movementSpeed = movement.ReadValue<Vector2>() * speed;

        body.linearVelocity = movementSpeed;
    }
}
