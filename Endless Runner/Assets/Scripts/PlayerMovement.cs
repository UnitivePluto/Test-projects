using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 5;
    public float multi = 2;

    float input;
    float input2;
    public Rigidbody body;

    public float speedIncrease = .1f;

    [SerializeField] float jumpForce = 600f;
    [SerializeField] LayerMask groundMask;

    private void FixedUpdate()
    {
        if(!alive)
        {
            return;
        }
        Vector3 forward= transform.forward * speed * Time.fixedDeltaTime;
        Vector3 dir = transform.right * input * speed * Time.fixedDeltaTime * multi;
        body.MovePosition(body.position + forward + dir);
    }
    void Update()
    {
        input = Input.GetAxis("Horizontal");
        input2 = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }

        if(transform.position.y<-5)
        {
            dead();
        }
    }
    public void dead()
    {
        alive = false;
        Invoke("res", 1);
    }
    public void res()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        body.AddForce(Vector3.up * jumpForce);
    }
}
