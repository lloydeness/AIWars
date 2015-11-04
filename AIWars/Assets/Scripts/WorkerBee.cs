using UnityEngine;
using System.Collections;

public class WorkerBee : SteeringBehaviour
{


  
    public Sensor SeekSensor;
    public Sensor sensor;
    public Sensor Lsensor;
    public Sensor Rsensor;
    public Sensor hitSensor;
    public Vector3 mineralPatch { get; set; }
    public Vector3 Base { get; set; }
    public bool isSelected { get; set; }
    public ObjectAttached attachedObject;
    public bool jobAssigned { get; set; }


    private Rigidbody rb3d;   
    private float timeStamp = 0;
    private Vector3 tempLocation;
    private bool goToMouse = false;
    private bool collecting = false;
    private bool hasMineral = false;
    public int hitPoints = 4;



    // Use this for initialization
    void Start()
    {
        maxSpeed = 3;
        turnSpeed = 0.2f;
        rb3d = this.GetComponentInParent<Rigidbody>();




    }

    // Update is called once per frame
    void Update()
    {
        int alive = 0;
        if (hitSensor.isColliding == true)
        {
            alive = hitPoints - hitSensor.targets.Count;

        }

        if (alive < 0)
        {
            rb3d.gameObject.SetActive(false);

        }


        attachedObject = this.GetComponentInChildren<ObjectAttached>();




        if (attachedObject != null)
        {


            if (Input.GetButtonDown("Fire2"))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray))
                {
                    print(ray.origin);
                    tempLocation = ray.origin;
                    tempLocation = new Vector3(tempLocation.x, 0, tempLocation.z);
                    goToMouse = true;

                }
            }
        }

        }

    void FixedUpdate()
    {



        if (Lsensor.isColliding == true || Rsensor.isColliding == true)
        {
            AdvancedCollisions(Lsensor, Rsensor);
        }
        else
        {
            if (goToMouse == true)
            {
                moveToPoint();

            }
            else
            {

                if (SeekSensor.isColliding == true)
                {


                    if (hasMineral == false)
                    {


                        Seek(mineralPatch, 1);

                    }
                    else
                    {
          
                        Seek(Base, 0);

                    }


                }
            }

        }








        if (collecting == true && goToMouse == false)
        {
            isCollecting();

        }
        else
        {

            ApplySteering();
            Reset();
        }

        if (rb3d.rotation.x != 90f)
        {
            Vector3 rot = rb3d.rotation.eulerAngles;
            rot = new Vector3(0, rot.y, rot.z);
            rb3d.rotation = Quaternion.Euler(rot);
        }


    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == ("Base"))
        {
            hasMineral = false;
        }

        if (target.gameObject.tag == ("Mineral"))
        {

            collecting = true;
            timeStamp = Time.time;
            rb3d.velocity = new Vector3(0, 0, 0);
        }

    }

    void OnCollisionExit(Collision target)
    {


        if (target.gameObject.tag == ("Mineral"))
        {

            collecting = false;

        }

    }

    void isCollecting()
    {
        if (Time.time > timeStamp + 5)
        {
            collecting = false;
            hasMineral = true;


        }

    }

    void moveToPoint()
    {
        Seek(tempLocation);

        if ((rb3d.transform.position.x - tempLocation.x) <= .05 && (rb3d.transform.position.z - tempLocation.z) <= .05)
        {
            goToMouse = false;
        }

    }



}