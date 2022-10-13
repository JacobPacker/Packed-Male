using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBreaking : MonoBehaviour
{
    public GameObject DestroyedVersion;
    public float yDistance = 1f;
    void OnCollisionEnter(Collision collision)
    {
        Instantiate(DestroyedVersion, new Vector3(transform.position.x, transform.position.y + yDistance, transform.position.z), transform.rotation);
        Destroy(collision.gameObject);
    }
}
