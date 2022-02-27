using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public float GravityModifier;

    private bool canJump;
    
    private Rigidbody rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        transform.eulerAngles = new Vector3(0, 90, 0);
    }

    private void Update()
    {
        anim.SetBool("CanJump", !canJump);
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
            rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 2.5f))
            canJump = true;
        else
            canJump = false;

        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, rb.velocity.y, rb.velocity.z);
        Debug.Log(Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") != 0)
            anim.SetBool("CanMove", true);
        else
            anim.SetBool("CanMove", false);

        if (rb.velocity.x < 0f)
            transform.eulerAngles = new Vector3(0, -90, 0);
        else if (rb.velocity.x > 0f)
            transform.eulerAngles = new Vector3(0, 90, 0);

        rb.velocity += new Vector3(0f, -9.81f, 0f) * GravityModifier * Time.deltaTime;
    }
}
