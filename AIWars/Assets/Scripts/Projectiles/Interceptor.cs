using UnityEngine;
using System.Collections;

public class Interceptor : MonoBehaviour {

    public Transform target { get; set; }
    public float speed { get; set; }
    public float turningSpeed { get; set; }
    public float timeStamp { get; set; }



    void Update()
    {


        if (Time.time > timeStamp + 7)
        {

            PoolManager.Instance.PoolObject(gameObject);
        }


    }
 

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate the direction from the current position to the target
        Vector3 targetDirection = (target.position + (target.GetComponent<Rigidbody>().velocity* 2) ) - transform.position;
        // Calculate the rotation required to point at the target
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        // Rotate from the current rotation towards the target rotation, but not
        // faster than mRotationSpeed degrees per second
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);
        // Move forward
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        if (GetComponent<Rigidbody>().rotation.x != 90f)
        {
            Vector3 rot = GetComponent<Rigidbody>().rotation.eulerAngles;
            rot = new Vector3(0, rot.y, rot.z);
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(rot);
        }
    }


}