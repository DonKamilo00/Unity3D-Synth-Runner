using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    private Collider playerCollider;

    public float distToGround;

    public float mileStone;
    private float mileStoneCount;
    public float speedMultiplier;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float gravityScale = 1f;
    private float globalGravity = -9.81f;

    private bool jumpRequest;


    public GameObject jumpParticles;
    public GameObject deathParticles;
    

    [Range(1, 20)]
    public float jumpVelocity;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        playerCollider = GetComponent<Collider>();
        distToGround = playerCollider.bounds.extents.y;

        mileStoneCount = mileStone;
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    private void FixedUpdate()
    {

        


        if (jumpRequest)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            jumpRequest = false;
            Debug.Log("works");
        }
        
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        if (rb.velocity.y < 0)
        {
            rb.AddForce(gravity * fallMultiplier, ForceMode.Acceleration);
        }
        else if (rb.velocity.y > 0 && !Input.GetMouseButton(0))
        {
            rb.AddForce(gravity * lowJumpMultiplier, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(gravity, ForceMode.Acceleration);
        }


       


    }

    void SpawnJumpParticles()
    {
        GameObject tmpParticles = Instantiate(jumpParticles,transform.position, Quaternion.Euler(90f, 0f, 0f));
        Destroy(tmpParticles, 3f);
    }


    void SpawnDeathParticles()
    {
        GameObject tmpParticles = Instantiate(deathParticles, new Vector3(transform.position.x,transform.position.y + 2,transform.position.z), Quaternion.Euler(-90f, 0f, 0f));
        Destroy(tmpParticles, 3f);
    }


    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.name == "Death")
        {

            SpawnDeathParticles();

            gameObject.SetActive(false);



        }





    }

    private void Update()
    {
        if (transform.position.x > mileStoneCount)
        {
            mileStoneCount += mileStone;
            speed = speed * speedMultiplier;
            mileStone += mileStone + speedMultiplier;

            Debug.Log("M" + mileStone + ",MC" + mileStoneCount + ",MS" + speed);
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            jumpRequest = true;
            Invoke("SpawnJumpParticles", 0.1f);
        }

        //bool grounded = Physics.IsTouchingLayers(playerCollider, ground);

        // if (Input.GetMouseButtonDown(0) && IsGrounded()  || Input.GetKeyDown(KeyCode.Space) && IsGrounded() )
        // {
        //rb.velocity = new Vector2(rb.velocity.x, jump);

        //}
    }
}