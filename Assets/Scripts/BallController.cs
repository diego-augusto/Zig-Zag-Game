using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField]
    private float speed;
    private bool started;
    private bool gameOver;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        started = false;
        gameOver = false;
    }

    void Update()
    {

        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                started = true;
                rb.velocity = new Vector3(speed, 0, 0);
            }
        }
        else if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDiretion();
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -10, 0);
            Camera.main.GetComponent<CameraController>().gameOver = true;
        }
    }

    private void SwitchDiretion()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
}
