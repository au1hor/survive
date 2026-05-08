using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public InputActionReference move;
    public PlayerStats stats;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = PlayerStats.instance;
    }
    public void FixedUpdate()
    {
        Vector2 vMove =move.action.ReadValue<Vector2>();
        moveInput(vMove * stats.speed);
    }
    public void moveInput(Vector2 value)
    {
        rb.linearVelocity = value;
    }
    void Update()
    {

    }
}
