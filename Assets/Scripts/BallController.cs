using UnityEngine;

public class BallController : MonoBehaviour
{

    public GameObject particle;

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
                GameManager.instance.StartGame();
            }
        }
        else if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDiretion();
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25, 0);  
            Camera.main.GetComponent<CameraController>().gameOver = true;
            GameManager.instance.GameOver();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Diamond"))
        {
            GameObject p = Instantiate(particle, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(p, 1.5f);
        }
    }
}
