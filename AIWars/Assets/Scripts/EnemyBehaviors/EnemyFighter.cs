using UnityEngine;
using System.Collections;

public class EnemyFighter : SteeringBehaviour
{

    private Rigidbody rb3d;
    public EnemySensor sensor;
    public Sensor Lsensor;
    public Sensor Rsensor;
    public Sensor hitSensor;
    public Transform seekTarget { get; set; }
    public bool hasTarget = false;
 
    public int hitPoints = 10;



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

    }

    void FixedUpdate()
    {



        if (hasTarget == true)
        {
            Seek(seekTarget.transform.position, 4);
        }
        else
        {
            





            if (Lsensor.isColliding == true || Rsensor.isColliding == true)
            {
                AdvancedCollisions(Lsensor, Rsensor);
            }


            if (Lsensor.isColliding == false && Rsensor.isColliding == false && sensor.targets.Count == 0)
            {
                Wander();
            }


        }

        ApplySteering();
        Reset();


        if (rb3d.rotation.x != 90f)
        {
            Vector3 rot = rb3d.rotation.eulerAngles;
            rot = new Vector3(0, rot.y, rot.z);
            rb3d.rotation = Quaternion.Euler(rot);
        }


    }



}
