using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ball;
    private Vector3 offset;
    public bool gameOver;

    void Start()
    {
        gameOver = false;
        offset = transform.position - ball.transform.position;
    }

    void LateUpdate()
    {
        if (!gameOver)
        {
            transform.position = ball.transform.position + offset;
        }
    }
}
