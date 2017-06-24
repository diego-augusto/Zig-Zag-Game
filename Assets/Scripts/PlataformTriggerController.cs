using UnityEngine;

public class PlataformTriggerController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            Invoke("Fall", 0.5f);
        }
    }

    private void Fall()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2.0f);
    }
}
