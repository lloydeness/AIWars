using UnityEngine;
using System.Collections;

public class MirrorWarp : MonoBehaviour
{
    public float minimumX;
    public float maximumX;
    public float minimumZ;
    public float maximumZ;

    void OnTriggerExit(Collider other)
    {
        Vector3 temp2 = other.transform.position;
        Vector3 temp = other.GetComponent<Rigidbody>().transform.position;

        if (temp.x < minimumX || temp.x > maximumX)
        {
            //warp horizontally
            temp.x *= -1;
        }

        if (temp.z < minimumZ || temp.z > maximumZ)
        {
            //warp vertically
            temp.z *= -1;
        }
        other.transform.position = temp;
    }
}
