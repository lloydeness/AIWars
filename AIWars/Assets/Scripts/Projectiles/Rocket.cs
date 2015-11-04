using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public float acceleration { get; set; }
    public Collider ignoreCollider { get; set; }

    // Update is called once per frame
    void FixedUpdate()
    {
        //apply forward acceleration
        GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity * acceleration, ForceMode.Force);
        //face the direction we are moving.
        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != ignoreCollider)
        {
            PoolManager.Instance.PoolObject(gameObject);
            if (other.tag == ("Player"))
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
