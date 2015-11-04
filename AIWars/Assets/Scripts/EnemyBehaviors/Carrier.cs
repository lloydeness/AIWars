using UnityEngine;
using System.Collections;

public class Carrier : SteeringBehaviour
{
    public Sensor sensor;
    public float avoidHullAmount;
    public int hitPoints = 100;
    public Sensor Lsensor;
    public Sensor Rsensor;
    public Sensor hitSensor;
   



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int alive = 0;
        if (hitSensor.isColliding == true)
        {
            alive = hitPoints - hitSensor.targets.Count;

        }

        if (alive < 0)
        {
            this.gameObject.SetActive(false);

        }


    }

    void FixedUpdate()
    {


        if (Lsensor.isColliding == false || Rsensor.isColliding == false)
        {
            Wander();
        }

       else
        {
            AdvancedCollisions(Lsensor, Rsensor);
        }
        
      

        ApplySteering();
        Reset();

        if (GetComponent<Rigidbody>().rotation.x != 90f)
        {
            Vector3 rot = GetComponent<Rigidbody>().rotation.eulerAngles;
            rot = new Vector3(90, rot.y, rot.z);
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(rot);
        }
    }
}
