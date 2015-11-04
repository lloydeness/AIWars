using UnityEngine;
using System.Collections;


public class AIMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public GameObject something;
    float posX = 0;
    float posY = 0;
    Vector3 moveDirection;




    void Awake()
    {
        moveDirection = new Vector3(0, 0, 0);
    }


    //Update is called once per frame
    void Update()
    {

        moveDirection = new Vector3(0, 0, 0);

        if (Input.GetAxis("Horizontal") != 0)
        {     
            posX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            moveDirection += new Vector3(posX, 0, 0);

        }

        if (Input.GetAxis("Vertical") != 0)
        {

            posY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            moveDirection += new Vector3(0, 0, posY);
        }


        GetComponent<Rigidbody>().velocity = moveDirection * 100;

        if (GetComponent<Rigidbody>().velocity != Vector3.zero)
        {

            Quaternion tempRot = Quaternion.LookRotation(moveDirection);
            Vector3 rot = tempRot.eulerAngles;
            rot = new Vector3(90, rot.y, rot.z);
            tempRot = Quaternion.Euler(rot);


            something.transform.rotation = Quaternion.Slerp(something.transform.rotation,tempRot, Time.deltaTime * 6);


        }






    }

    private void FixedUpdate()
    {
  


    }



}


