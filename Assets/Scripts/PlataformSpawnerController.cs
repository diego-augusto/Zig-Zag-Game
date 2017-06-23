using UnityEngine;

public class PlataformSpawnerController : MonoBehaviour
{

    public GameObject plataform;
    private Vector3 lastpos;
    private float plataformSize;

    void Start()
    {
        lastpos = plataform.transform.position;
        plataformSize = plataform.transform.localScale.x;

        for (int i = 0; i < 5; i++)
        {
            SpawnX();
        }

        for (int i = 0; i < 5; i++)
        {
            SpawnZ();
        }
    }

    void Update()
    {

    }

    public void SpawnX()
    {
        Vector3 pos = lastpos;
        pos.x += plataformSize;
        Instantiate(plataform, pos, Quaternion.identity);
        lastpos = pos;
    }

    public void SpawnZ()
    {
        Vector3 pos = lastpos;
        pos.z += plataformSize;
        Instantiate(plataform, pos, Quaternion.identity);
        lastpos = pos;
    }
}
