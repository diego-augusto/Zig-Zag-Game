using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField]
    private float speed;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwitchDiretion();
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
