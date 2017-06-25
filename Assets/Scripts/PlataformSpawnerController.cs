using UnityEngine;

public class PlataformSpawnerController : MonoBehaviour
{

    public GameObject plataform;
    public GameObject diamond;
    private Vector3 lastpos;
    private float plataformSize;
    public bool gameOver;

    void Start()
    {
        gameOver = false;

        lastpos = plataform.transform.position;
        plataformSize = plataform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnPlataform();
        }
    }

    public void SpawningPlataforms()
    {
        InvokeRepeating("SpawnPlataform", 0.1f, 0.2f);
    }

    void Update()
    {
        if (GameManager.instance.gameOver)
        {
            CancelInvoke("SpawnPlataform");
        }
    }

    public void SpawnPlataform()
    {
        int randomNumber = Random.Range(0, 6);

        if (randomNumber < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }

    public void SpawnX()
    {
        Vector3 pos = lastpos;
        pos.x += plataformSize;
        Instantiate(plataform, pos, Quaternion.identity);

        int randomNumber = Random.Range(0, 10);
        if (randomNumber < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }

        lastpos = pos;
    }

    public void SpawnZ()
    {
        Vector3 pos = lastpos;
        pos.z += plataformSize;
        Instantiate(plataform, pos, Quaternion.identity);

        int randomNumber = Random.Range(0, 10);
        if (randomNumber < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }

        lastpos = pos;
    }
}
