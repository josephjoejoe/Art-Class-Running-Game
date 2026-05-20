using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float jumpForce;

    public Rigidbody2D RB;

    //box Cast for ground detection 
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    //public bool OnGround;

    Animator anim;
    public bool Moving;
    public bool Jumping;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x);

        Vector2 vel = new Vector2(0, RB.linearVelocity.y);

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -Speed;
            newScale.x = -currentScale;
            Moving = true;
        }

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = Speed;
            newScale.x = currentScale;
            Moving = true;
        }

        if (Input.GetKey("w") && isGrounded() || Input.GetKey(KeyCode.UpArrow) && isGrounded())
        {
            // velocity is a vector 
            vel.y = jumpForce;
        }
       
        if(isGrounded() == false)
        {
            Jumping = true;
        }

        if (isGrounded() == true)
        {
            Jumping = false;
        }

        if (Input.GetKeyUp("a") || Input.GetKeyUp("d") || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Moving = false;
        }

        RB.linearVelocity = vel;

        anim.SetBool("Moving", Moving);
        anim.SetBool("Jumping", Jumping);
        transform.localScale = newScale;
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

}
