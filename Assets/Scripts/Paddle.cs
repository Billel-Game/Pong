using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float moveSpeed = 10f;
    public string verticalInputAxis = "Vertical";

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

void Update()
{
    float moveInput = Input.GetAxis(verticalInputAxis);
    rb.velocity = new Vector2(0, moveInput * moveSpeed);
}

}
