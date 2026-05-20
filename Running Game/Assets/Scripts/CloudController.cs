using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float Speed;
    public float jumpForce;

    public Rigidbody2D RB;

    public float constantSpeedLeft = 0.25f;
    public float constantSpeedRight = 0.50f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2(0, RB.linearVelocity.y);

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
            transform.Translate(Vector3.right * constantSpeedRight * Time.deltaTime);
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
            constantSpeedLeft = 0.50f;
           
        }
        else
        {
            constantSpeedLeft = 0.25f;
        }

        transform.Translate(Vector3.left * constantSpeedLeft * Time.deltaTime);


        RB.linearVelocity = vel;
    }
}

